using System;
using System.Windows.Forms;

public class Combo_ComboBox
{
	public static void Formatar(ComboBox Combo, 
							    string ValueMember, 
							    string DisplayMember, 
								ComboBoxStyle DropDownStyle = ComboBoxStyle.DropDown,
								object DataSource = null)
	{
		Combo.ValueMember = ValueMember;
		Combo.DisplayMember = DisplayMember;
		Combo.DropDownStyle = DropDownStyle;
		Combo.DataSource = DataSource;
	}
}
