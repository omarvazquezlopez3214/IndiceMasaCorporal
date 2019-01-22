using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndiceDeMasaCorporal
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnCalcular_Click(object sender, EventArgs e)
		{
			string nombre;
			int edad;
			string sexo;
			//Validación de campos vacios
			if(txtNombre.Text == "" || txtEdad.Text == "" || txtEstatura.Text == "" || txtPeso.Text == "")
			{
				MessageBox.Show("Hace falta llenar algun campo.");
				return;
			}
			if(!(rbMasculino.Checked || rbFemenino.Checked))
			{
				MessageBox.Show("Hace falta seleccionar el sexo.");
				return;
			}
			//Validación del campo de texto Nombre
			Regex expresionRegularNombre = new Regex("[A-Za-z0-9]");

			if (expresionRegularNombre.IsMatch(txtNombre.Text))
			{
				nombre = txtNombre.Text;
			}
			else
			{
				MessageBox.Show("Solo valores alfanuméricos");
				return;
			}
			//Validación del campo de texto Edad
			Regex expresionRegularEdad = new Regex("[0-9]");

			if(expresionRegularEdad.IsMatch(txtEdad.Text))
			{
				edad = Int32.Parse(txtEdad.Text);
			}
			else
			{
				MessageBox.Show("Solo valores numéricos");
				return;
			}

			//Validación del campo de sexo
			if(rbMasculino.Checked)
			{
				sexo = "Hombre";
			}
			else if(rbFemenino.Checked)
			{
				sexo = "Mujer";
			}

		}
	}
}
