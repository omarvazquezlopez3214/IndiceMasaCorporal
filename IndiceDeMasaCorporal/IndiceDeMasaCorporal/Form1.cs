﻿using System;
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
			double est, pe;
			string nombre;
			int edad;
			string sexo = string.Empty;
			int peso;
			int estatura;
			string es, pes;
			//Validación de campos vacios
			if (txtNombre.Text == "" || txtEdad.Text == "" || txtEstatura.Text == "" || txtPeso.Text == "")
			{
				MessageBox.Show("Hace falta llenar algun campo.");
				return;
			}
			if (!(rbMasculino.Checked || rbFemenino.Checked))
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

			if (expresionRegularEdad.IsMatch(txtEdad.Text))
			{
				edad = Int32.Parse(txtEdad.Text);
			}
			else
			{
				MessageBox.Show("Solo valores numéricos");
				return;
			}

			//Validación del campo de sexo
			if (rbMasculino.Checked)
			{
				sexo = "Hombre";
			}
			else if (rbFemenino.Checked)
			{
				sexo = "Mujer";
			}

			//Validación del campo estatura
			Regex expresionRegularEstatura = new Regex(@"^\d+$");
			if (expresionRegularEstatura.IsMatch(txtEstatura.Text))
			{
				estatura = Int32.Parse(txtEstatura.Text);
				txtEstatura.Text = string.Format("{0:F2}",Convert.ToDouble(txtEstatura.Text));
				es = txtEstatura.Text;
				//est = double.Parse(es) / 100;
			}
			else
			{
				MessageBox.Show("Solo valores numéricos enteros");
				return;
			}
			//Validación del campo peso
			Regex expresionRegularPeso = new Regex(@"^\d+$");
			if (expresionRegularPeso.IsMatch(txtPeso.Text))
			{
				peso = Int32.Parse(txtPeso.Text);
				txtPeso.Text = string.Format("{0:F2}",Convert.ToDouble(txtPeso.Text));
				pes = txtPeso.Text;
				//pe = double.Parse(pes) / 100;
			}
			else
			{
				MessageBox.Show("Solo valores numéricos enteros");
				return;
			}
			double p = CalcularPesoIdeal(es);
			double i = CalcularIMC(es, pes);

			string composicionCorporal = string.Empty;

			if(i <= 18.5F)
			{
				composicionCorporal = "Peso inferior al normal";
			}
			else if(i >= 18.5F && i <= 24.9F)
			{
				composicionCorporal = "Normal";
			}
			else if(i >= 25.0F && i <= 29.9F)
			{
				composicionCorporal = "Peso superior al normal";
			}
			else if(i >= 30.0F)
			{
				composicionCorporal = "Obesidad";
			}

			label7.Text = "Nombre: "+ nombre + Environment.NewLine +
										"Edad: "+ edad + "años" + Environment.NewLine +
										"Sexo: "+ sexo + Environment.NewLine +
										"Peso Actual: "+ peso + "kg" + Environment.NewLine +
										"Estatura: "+estatura + "cm" + Environment.NewLine +
										"IMC: "+ i + "-->" + composicionCorporal + Environment.NewLine +
										"Peso Ideal: "+ p + "kg" + Environment.NewLine + Environment.NewLine;

		}

		public static double CalcularPesoIdeal(string estatura)
		{
			double pesoIdeal;
			double a = 0.75;
			pesoIdeal = (a *(double.Parse(estatura) - 150) + 50);

			return pesoIdeal;
		}

		public static double CalcularIMC(string estatura, string peso)
		{
			double IMC;
			IMC = ((double.Parse(peso)) /100) / Math.Pow((double.Parse(estatura)) / 100,2) * 100;
			//IMC = (peso /(estatura * estatura) * 10000);
			//IMC = peso / Math.Pow(estatura, 2);
			double d = Math.Round(IMC, 2);
			return d;
		}
	}

}
