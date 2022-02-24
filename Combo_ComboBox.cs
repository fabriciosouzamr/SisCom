using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
	}

	public static bool Selecionado(ComboBox Combo)
    {
		return (Combo.SelectedIndex != -1);
    }

	public static void Selecionar(ComboBox Combo, object Valor, int Posicao)
    {
		 
		foreach (IEnumerable<Type> Item in Combo.Items)
		{
			if (Item == Valor)
            {
				Combo.SelectedItem = Item;
				return;
			}
        }
    }
}
