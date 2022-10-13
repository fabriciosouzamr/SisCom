using Funcoes.Interfaces;
using SisCom.Aplicacao.Classes;
using SisCom.Aplicacao.Controllers;
using SisCom.Aplicacao.Formularios;
using SisCom.Aplicacao.ViewModels;
using SisCom.Infraestrutura.Data.Context;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Combo_ComboBox
{
	public static void Formatar(ComboBox Combo, 
							    string ValueMember, 
							    string DisplayMember, 
								ComboBoxStyle DropDownStyle = ComboBoxStyle.DropDown,
								object DataSource = null,
								Type myEnum = null)
	{
		Combo.Tag = Declaracoes.ComboBox_Carregando;
		Combo.DataSource = null;
		Combo.ValueMember = ValueMember;
		Combo.DisplayMember = DisplayMember;
		Combo.DropDownStyle = DropDownStyle;

		if (DataSource != null)
		{
			Combo.DataSource = DataSource;
		}
		else if (myEnum != null)
		{
			Combo.ValueMember = "Value";
			Combo.DisplayMember = "Description";
			Combo.DataSource = Enum.GetValues(myEnum)
									.Cast<Enum>()
									.Select(value => new {
										(Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
										value })
									.OrderBy(item => item.value)
									.ToList();
		}
		try { Combo.SelectedIndex = -1; } catch (Exception) { }
		Combo.Tag = null;
	}

	public static bool Selecionado(ComboBox Combo)
    {
		return (Combo.SelectedIndex != -1);
    }

	public static void Selecionar(ComboBox Combo, object Valor, object campo)
    {
		 
		foreach (object Item in Combo.Items)
		{
			if (Item == Valor)
            {
				Combo.SelectedItem = Item;
				return;
			}
        }
	}
	public static void Selecionar(ComboBox Combo, string Valor)
	{
		CodigoNomeComboViewModel item;

		for (int i = 0; i <= Combo.Items.Count -1 ; i += 1)
		{
			item = (CodigoNomeComboViewModel)Combo.Items[i];
			if (Funcoes._Classes.Texto.ContainsInsensitive(item.Codigo, Valor))
            {
				Combo.SelectedIndex = i;
				return;

			}
		}
	}
	public static Guid? NaoSelecionadoParaNuloGuid(ComboBox combo)
    {
		if (Selecionado(combo))
        {
			return (Guid)combo.SelectedValue;
        }
		else
		{
			return null;
		}
	}

	public async static void ComboCidade_Carregar(IServiceProvider serviceProvider,
												  IServiceScopeFactory<MeuDbContext> dbCtxFactory,
												  INotifier _notifier, 
												  Guid? CidadeId, 
												  ComboBox comboCidade, 
												  ComboBox comboEstado, 
												  ComboBox comboPais)
	{
		comboCidade.Enabled = false;
		comboEstado.Enabled = false;
		if (comboPais != null) { comboPais.Enabled = false; }

		try
        {

        }
        catch (Exception)
        {

            throw;
        }
		FormMain main = new FormMain(serviceProvider, dbCtxFactory, _notifier);

		Guid estadoId = (await (new CidadeController(main.MeuDbContext(), _notifier)).GetById((Guid)CidadeId)).EstadoId;
		string estadoCodigo = (await (new EstadoController(main.MeuDbContext(), _notifier)).GetById(estadoId)).Codigo;
		Combo_ComboBox.Selecionar(comboEstado, estadoCodigo);

		if (Selecionado(comboEstado))
        {
			Combo_ComboBox.Formatar(comboCidade,
									"ID", "Nome",
									ComboBoxStyle.DropDownList,
									await (new CidadeController(main.MeuDbContext(), _notifier)).ComboEstado((Guid)comboEstado.SelectedValue, p => p.Nome));
			await Task.Delay(500);
			comboCidade.SelectedValue = CidadeId;

			if (comboPais != null)
			{
				Guid paisId = (await (new EstadoController(main.MeuDbContext(), _notifier)).GetById((Guid)comboEstado.SelectedValue)).PaisId;
				Combo_ComboBox.Formatar(comboPais,
										"ID", "Nome",
										ComboBoxStyle.DropDownList,
										await (new PaisController(main.MeuDbContext(), _notifier)).ComboId(paisId));
				comboPais.SelectedValue = paisId;
			}
		}

		main.MeuDbContextDispose(); 
		
		comboCidade.Enabled = true;
		comboEstado.Enabled = true;
		if (comboPais != null) { comboPais.Enabled = true; }

	}
}
