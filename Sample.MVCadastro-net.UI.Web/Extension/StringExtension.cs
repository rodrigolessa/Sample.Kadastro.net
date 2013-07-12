using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Sample.MVCadastro_net.UI.Web.Extension
{
    public static class StringExtension
    {
        public static string ToCPF(this string valor)
        {
            return FormataMascara(@"###.###.###-##", valor);
        }

        public static string ToCNPJ(this string valor)
        {
            return FormataMascara(@"##.###.###/####-##", valor);
        }

        private static string FormataMascara(string mascara, string valor)
        {
            StringBuilder formatado = new StringBuilder();

            //int total = mascara.Count(x => x.Equals(Convert.ToChar("#")));
            int posicao = 0;

            for (int i = 0; mascara.Length > i; i++)
            {
                if (mascara[i] == Convert.ToChar("#"))
                {
                    if (valor.Length > posicao)
                    {
                        formatado.Append(valor[posicao].ToString());
                        posicao++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    formatado.Append(mascara[i].ToString());
                }
            }

            return formatado.ToString();
        }
    }
}