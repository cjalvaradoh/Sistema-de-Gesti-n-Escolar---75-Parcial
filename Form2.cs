using System;
using System.IO;
using System.Windows.Forms;

namespace Sistema_de_Gestión_Escolar___75__Parcial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = textBox1.Text;
                string contraseña = textBox2.Text;
                string filePath = @"C:\Users\Ces\source\repos\Sistema de Gestión Escolar - 75% Parcial\Sistema de Gestión Escolar - 75% Parcial\bin\Debug\usuarioscole.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(usuario + ":" + contraseña);
                }

                MessageBox.Show("Usuario registrado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}