using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_egipcios
{
    public partial class Numeros_Egipcios : Form
    {
        private Dictionary<int, string> ideogramas;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public Numeros_Egipcios()
        {
            InitializeComponent();
            ideogramas = new Dictionary<int, string>()
            {
                {1,"𓏤"},
                {10,"𓎆"},
                {100,"𓍢" },
                {1000,"𓆼" },
                {10000,"𓂭" },
                {100000,"𓆐"},
                {1000000,"𓁨"},
                {10000000,"𓆈𓏼"}


        };
        }

        private void txtDecimal_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDecimal.Text))
            {


                if (Int32.Parse(txtDecimal.Text) >= 1 && Int32.Parse(txtDecimal.Text) < 10)
                {

                    string valor = "";
                    string resultado = "";
                    int Largonumero = Int32.Parse(txtDecimal.Text);
                    ideogramas.TryGetValue(1, out valor);

                    textarea_Egipcio.Text = Calcular0a9(resultado, valor, Largonumero);
                }
                else if (Int32.Parse(txtDecimal.Text) >= 10 && Int32.Parse(txtDecimal.Text) <= 99)
                {

                    string valor = "";
                    string resultado = "";
                    int Largo10Usar = Int32.Parse(txtDecimal.Text) / 10;
                    ideogramas.TryGetValue(10, out valor);

                    textarea_Egipcio.Text = Calcular10a99(resultado, valor, Largo10Usar);
                }
                else if (Int32.Parse(txtDecimal.Text) >= 100 && Int32.Parse(txtDecimal.Text) <= 999)
                {

                    string valor = "";
                    int Largo10Usar = Int32.Parse(txtDecimal.Text) / 100;
                    ideogramas.TryGetValue(100, out valor);

                    string resultado = "";
                    textarea_Egipcio.Text = Calcular100a999(resultado, valor, Largo10Usar);

                }
                else if (Int32.Parse(txtDecimal.Text) >= 1000 && Int32.Parse(txtDecimal.Text) <= 9999)
                {

                    string valor = "";
                    int Largo1000Usar = Int32.Parse(txtDecimal.Text) / 1000;
                    ideogramas.TryGetValue(1000, out valor);

                    string resultado = "";
                    textarea_Egipcio.Text = Calcular1000a9999(resultado, valor, Largo1000Usar);
                }
                else if (Int32.Parse(txtDecimal.Text) >= 10000 && Int32.Parse(txtDecimal.Text) <= 99999)
                {

                    string valor = "";
                    int Largo10000Usar = Int32.Parse(txtDecimal.Text) / 10000;
                    ideogramas.TryGetValue(10000, out valor);

                    string resultado = "";
                    textarea_Egipcio.Text = Calcular10000a99999(resultado, valor, Largo10000Usar);
                }
                else if (Int32.Parse(txtDecimal.Text) >= 100000 && Int32.Parse(txtDecimal.Text) <= 999999)
                {

                    string valor = "";
                    int Largo100000Usar = Int32.Parse(txtDecimal.Text) / 100000;
                    ideogramas.TryGetValue(100000, out valor);

                    string resultado = "";
                    textarea_Egipcio.Text = Calcular100000a999999(resultado, valor, Largo100000Usar);
                }
                else if (Int32.Parse(txtDecimal.Text) >= 1000000 && Int32.Parse(txtDecimal.Text) <= 9999999)
                {

                    string valor = "";
                    int Largo1000000Usar = Int32.Parse(txtDecimal.Text) / 1000000;
                    ideogramas.TryGetValue(1000000, out valor);

                    string resultado = "";
                    textarea_Egipcio.Text = Calcular1000000a9999999(resultado, valor, Largo1000000Usar);
                }
                else if (Int32.Parse(txtDecimal.Text) >= 10000000)
                {

                    string valor = "";
                    ideogramas.TryGetValue(10000000, out valor);
                    textarea_Egipcio.Text = "Muchos millones " +valor;
                }
            }
        }
      
            private string Calcular1000000a9999999(string resultado, string valor, int Largo1000000Usar)
        {

            int conteoSalto = 0;

            for (int i = 0; i < Largo1000000Usar; i++)//LLenar con el simbolo de 1000000
            {
                if (conteoSalto % 5 == 1 && conteoSalto >= 5) resultado += "\t" + valor;
                else resultado += valor;

                conteoSalto++;
            }
            //Calculamos 100000
            int largo = txtDecimal.Text.Length;

            if (largo == 6)
            {

                ideogramas.TryGetValue(100000, out valor);
                resultado = Calcular100000a999999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(0).ToString()));


            }
            else if (largo == 7)
            {

                ideogramas.TryGetValue(100000, out valor);
                resultado = Calcular100000a999999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(1).ToString()));


            }
            return resultado;
        }
        private string Calcular100000a999999(string resultado, string valor, int Largo100000Usar)
        {

            int conteoSalto = 0;

            for (int i = 0; i < Largo100000Usar; i++)//LLenar con el simbolo de 100000
            {
                if (conteoSalto % 5 == 1 && conteoSalto >= 5) resultado += "\t" + valor;
                else resultado += valor;

                conteoSalto++;
            }
            //Calculamos 10000
            int largo = txtDecimal.Text.Length;

            if (largo == 5)
            {
                
                    ideogramas.TryGetValue(10000, out valor);
                    resultado = Calcular10000a99999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(0).ToString()));
                

            }
            else if (largo == 6)
            {
                
                    ideogramas.TryGetValue(10000, out valor);
                    resultado = Calcular10000a99999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(1).ToString()));
                

            }
            else if (largo == 7)
            {
                
                    ideogramas.TryGetValue(10000, out valor);
                    resultado = Calcular10000a99999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(2).ToString()));
                

            }
            return resultado;
        }
        private string Calcular10000a99999(string resultado, string valor, int Largo1000Usar)
        {
            int conteoSalto = 0;

            for (int i = 0; i < Largo1000Usar; i++)//LLenar con el simbolo de 10000
            {
                if (conteoSalto % 5 == 1 && conteoSalto >= 5) resultado += "\t" + valor;
                else resultado += valor;

                conteoSalto++;
            }
            //Calculamos 1000
            int largo = txtDecimal.Text.Length;

           if (largo == 4)
            {
               ideogramas.TryGetValue(1000, out valor);
                    resultado = Calcular1000a9999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(0).ToString()));
                

            }
            else if (largo == 5)
            {
                
                    ideogramas.TryGetValue(1000, out valor);
                    resultado = Calcular1000a9999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(1).ToString()));
                

            }
            else if (largo == 6)
            {
               
                    ideogramas.TryGetValue(1000, out valor);
                    resultado = Calcular1000a9999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(2).ToString()));
                

            }
            else if (largo == 7)
            {
               
                    ideogramas.TryGetValue(1000, out valor);
                    resultado = Calcular1000a9999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(3).ToString()));
                

            }
            return resultado;
        }
            private string Calcular1000a9999(string resultado, string valor, int Largo1000Usar)
        {

            int conteoSalto = 0;

            for (int i = 0; i < Largo1000Usar; i++)//LLenar con el simbolo de 1000
            {
                if (conteoSalto % 5 == 1 && conteoSalto >= 5) resultado += "\t" + valor;
                else resultado += valor;

                conteoSalto++;
            }
            //Calculamos 100
            int largo = txtDecimal.Text.Length;

             if (largo == 3)
            {
                if (int.Parse(txtDecimal.Text.ElementAt(0).ToString()) != 0)
                {
                    ideogramas.TryGetValue(100, out valor);
                    resultado = Calcular100a999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(0).ToString()));
                }
               
            }
            else if (largo == 4)
            {
                if (int.Parse(txtDecimal.Text.ElementAt(1).ToString()) != 0)
                {
                    ideogramas.TryGetValue(100, out valor);
                    resultado = Calcular100a999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(1).ToString()));
                }
                    
            }
            else if (largo == 5)
            {
                if (int.Parse(txtDecimal.Text.ElementAt(2).ToString()) != 0)
                {
                    ideogramas.TryGetValue(100, out valor);
                    resultado = Calcular100a999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(2).ToString()));
                }
                    
            }
            else if (largo == 6)
            {
                if (int.Parse(txtDecimal.Text.ElementAt(3).ToString()) != 0)
                {
                    ideogramas.TryGetValue(100, out valor);
                    resultado = Calcular100a999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(3).ToString()));
                }
                    
            }
            else if (largo == 7)
            {
                if (int.Parse(txtDecimal.Text.ElementAt(4).ToString()) != 0)
                {
                    ideogramas.TryGetValue(100, out valor);
                    resultado = Calcular100a999(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(4).ToString()));
                }
                    
            }
            return resultado;
        }
        private string Calcular100a999(string resultado,string valor,int Largo10Usar)
        {
           
            int conteoSalto = 0;

            for (int i = 0; i < Largo10Usar; i++)//LLenar con el simbolo de 100
            {
                if (conteoSalto % 5 == 1 && conteoSalto >= 5) resultado += "\t" + valor;
                else resultado += valor;

                conteoSalto++;
            }
            //Calculamos los de 10
            int largo = txtDecimal.Text.Length;
            
            if (largo == 2)
            {

                ideogramas.TryGetValue(10, out valor);
                resultado = Calcular10a99(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(0).ToString()));
            }
            else if (largo == 3)
            {

                ideogramas.TryGetValue(10, out valor);
                resultado = Calcular10a99(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(1).ToString()));
            }
            else if (largo == 4)
            {

                ideogramas.TryGetValue(10, out valor);
                resultado = Calcular10a99(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(2).ToString()));
            }
            else if (largo == 5)
            {

                ideogramas.TryGetValue(10, out valor);
                resultado = Calcular10a99(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(3).ToString()));
            }
            else if (largo == 6)
            {

                ideogramas.TryGetValue(10, out valor);
                resultado = Calcular10a99(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(4).ToString()));
            }
            else if (largo == 7)
            {


                ideogramas.TryGetValue(10, out valor);
                resultado = Calcular10a99(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(5).ToString()));
            }
                   
            return resultado;
        }

        private string Calcular10a99(string resultado,string valor, int Largo10Usar)
        {
               
                int conteoSalto = 0;

                for (int i = 0; i < Largo10Usar; i++)//LLenar con el simbolo de 10
                {
                    if (conteoSalto % 5 == 1 && conteoSalto >= 5) resultado += "\t" + valor;
                    else resultado += valor;

                    conteoSalto++;
                }
                conteoSalto = 0;
            //Calculamos los de 0-9
            int largo = txtDecimal.Text.Length;
            if (largo == 1)
            {

                ideogramas.TryGetValue(1, out valor);
                resultado = Calcular0a9(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(0).ToString()));
            }
            else if (largo == 2)
            {

                ideogramas.TryGetValue(1, out valor);
                resultado = Calcular0a9(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(1).ToString()));
            }
            else if (largo == 3)
            {

                ideogramas.TryGetValue(1, out valor);
                resultado = Calcular0a9(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(2).ToString()));
            }
            else if (largo == 4)
            {

                ideogramas.TryGetValue(1, out valor);
                resultado = Calcular0a9(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(3).ToString()));
            }
            else if (largo == 5)
            {

                ideogramas.TryGetValue(1, out valor);
                resultado = Calcular0a9(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(4).ToString()));
            }
            else if (largo == 6)
            {

                ideogramas.TryGetValue(1, out valor);
                resultado = Calcular0a9(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(5).ToString()));
            }
            else if (largo == 7) {


                ideogramas.TryGetValue(1, out valor);
                resultado = Calcular0a9(resultado, valor, int.Parse(txtDecimal.Text.ElementAt(6).ToString()));
            }
                return resultado;
            }
        
        private String Calcular0a9(string resultado,string valor,int Largonumero)
        {
            if (Largonumero >= 1 && Largonumero < 10)
            {

                
                int conteoSalto = 0;

                for (int i = 0; i < Largonumero; i++)
                {
                    if (conteoSalto % 5 == 1 && conteoSalto >= 5) resultado += "\t" + valor;
                    else resultado += valor;

                    conteoSalto++;
                }
               
            }
                return resultado;
            }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
