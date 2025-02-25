﻿using System;

namespace Boleto2Net.Extensions
{
    public static class StringExtensions
    {
        public static string Right(this string value, int length)
        {
            if (String.IsNullOrEmpty(value))
                return string.Empty;
            return value.Length <= length ? value : value.Substring(value.Length - length);
        }
        public static string Left(this string value, int length)
        {
            if (String.IsNullOrEmpty(value))
                return string.Empty;
            return value.Length <= length ? value : value.Substring(0, length);
        }

        public static string MidVB(this string str, int start, int length)
        {
            return str.Mid(--start,length);
        }

        public static string Mid(this string str, int startIndex, int length)
        {
            if (str.Length <= 0 || startIndex >= str.Length) return string.Empty;
            if (startIndex + length > str.Length)
            {
                length = str.Length - startIndex;
            }
            return str.Substring(startIndex, length);
        }

        public static string CalcularDVCaixa(this string texto)
        {
            string digito;
            int pesoMaximo = 9, soma = 0, peso = 2;
            for (var i = texto.Length - 1; i >= 0; i--)
            {
                soma = soma + Convert.ToInt32(texto.Substring(i, 1)) * peso;
                if (peso == pesoMaximo)
                    peso = 2;
                else
                    peso = peso + 1;
            }
            var resto = soma % 11;
            if (resto <= 1)
                digito = "0";
            else
                digito = (11 - resto).ToString();
            return digito;
        }

        public static string CalcularDVSantander(this string texto)
        {
            string digito;
            int pesoMaximo = 9, soma = 0, peso = 2;
            for (var i = texto.Length - 1; i >= 0; i--)
            {
                soma = soma + Convert.ToInt32(texto.Substring(i, 1)) * peso;
                if (peso == pesoMaximo)
                    peso = 2;
                else
                    peso = peso + 1;
            }
            var resto = soma % 11;
            if (resto <= 1)
                digito = "0";
            else
                digito = (11 - resto).ToString();
            return digito;
        }

        public static string CalcularDVSicoob(this string texto)
        {
            string digito, fatorMultiplicacao = "319731973197319731973";
            int soma = 0;
            for (int i = 0; i < 21; i++)
            {
                soma += Convert.ToInt16(texto.Substring(i, 1)) * Convert.ToInt16(fatorMultiplicacao.Substring(i, 1));
            }
            int resto = (soma % 11);
            if (resto <= 1)
                digito = "0";
            else
                digito = (11 - resto).ToString();
            return digito;
        }

        public static string CalcularDVBradesco(this string texto)
        {
            string digito;
            int pesoMaximo = 7, soma = 0, peso = 2;
            for (var i = texto.Length - 1; i >= 0; i--)
            {
                soma = soma + (int)char.GetNumericValue(texto[i]) * peso;
                if (peso == pesoMaximo)
                    peso = 2;
                else
                    peso = peso + 1;
            }
            var resto = soma % 11;
            switch (resto)
            {
                case 0:
                    digito = "0";
                    break;
                case 1:
                    digito = "P";
                    break;
                default:
                    digito = (11 - resto).ToString();
                    break;
            }
            return digito;
        }

        public static string CalcularDVItau(this string texto)
        {
            string digito;
            int soma = 0, peso = 2, digTmp = 0;
            for (var i = texto.Length - 1; i >= 0; i--)
            {
                digTmp = (int)char.GetNumericValue(texto[i]) * peso;
                if (digTmp > 9)
                    digTmp = (digTmp / 10) + (digTmp % 10);

                soma = soma + digTmp;

                if (peso == 2)
                    peso = 1;
                else
                    peso = peso + 1;
            }
            var resto = (soma % 10);
            if (resto == 0)
                digito = "0";
            else
                digito = (10 - resto).ToString();
            return digito;
        }

        public static string CalcularDVSafra(this string texto)
        {
            string digito;
            int pesoMaximo = 9, soma = 0, peso = 2;
            for (var i = texto.Length - 1; i >= 0; i--)
            {
                soma = soma + (int)char.GetNumericValue(texto[i]) * peso;
                if (peso == pesoMaximo)
                    peso = 2;
                else
                    peso = peso + 1;
            }
            var resto = soma % 11;
            switch (resto)
            {
                case 0:
                    digito = "1";
                    break;
                case 1:
                    digito = "0";
                    break;
                default:
                    digito = (11 - resto).ToString();
                    break;
            }
            return digito;
        }

        public static string CalcularDVABC(this string texto)
        {
            string digito;
            int soma = 0, peso = 2, digTmp = 0;

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                digTmp = Convert.ToInt32(texto.Substring(i, 1)) * peso;
                for (int n = 0; n < digTmp.ToString().Length; n++)
                    soma += Convert.ToInt32(digTmp.ToString().Substring(n, 1));

                if (peso == 2)
                    peso = 1;
                else
                    peso = peso + 1;
            }

            var resto = (soma % 10);
            if (resto == 0)
                digito = "0";
            else
                digito = (10 - resto).ToString();
            return digito;
        }
        
        public static string CalcularDVDaycoval(this string texto)
        {
            string digito;
            int soma = 0, peso = 2, digTmp = 0;

            for (int i = texto.Length - 1; i >= 0; i--)
            {
                digTmp = Convert.ToInt32(texto.Substring(i, 1)) * peso;
                for (int n = 0; n < digTmp.ToString().Length; n++)
                    soma += Convert.ToInt32(digTmp.ToString().Substring(n, 1));

                if (peso == 2)
                    peso = 1;
                else
                    peso = peso + 1;
            }

            var resto = (soma % 10);
            if (resto == 0)
                digito = "0";
            else
                digito = (10 - resto).ToString();
            return digito;
        }
        
    }
}