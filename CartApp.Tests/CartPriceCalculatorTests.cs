using CartApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.IO;

namespace CartApp.Tests
{
    public class CartPriceCalculatorTests
    {
        private CartPriceCalculator _calculadora; 

        [SetUp]
        public void Setup()
        {
            _calculadora = new CartPriceCalculator(); 
        }

        [Test]
        public void Test_CarritoVacio_DevuelveCero() 
        {
            var listaVaciaDeItems = new List<Item>();
            string? codigoCupon = null; 
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(listaVaciaDeItems, codigoCupon, esVIP, enviarEmail); 


            Assert.That(resultado, Is.EqualTo(0m));
        }

        [Test]
        public void Test_ItemUnico_100_SinCupon_NoVip_Total142_00()
        {
            List<Item> productos = new List<Item> 
            {
                new Item("Taza", 100m, false),
            };

            string? codigoCupon = null;
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(142m));
        }
        [Test]
        public void Test_ItemUnico_250_SinCupon_NoVip_Total280_00() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("Plato", 250m, false),
            };

            string? codigoCupon = null;
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(280m));
        }
        [Test]
        public void Test_DosItems_80_60_ConPROMO10_Total171_12() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("A", 80m, false),
                new Item("B", 60m, false),
            };

            string? codigoCupon = "PROMO10";
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(171.12m));

        }
        [Test]
        public void Test_Fragil_210_ConPROMO10_Total226_68() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("Florero", 210m, true),
            };

            string? codigoCupon = "PROMO10";
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(226.68m));
        }
        [Test]
        public void Test_DosFragiles_90_120_SinCupon_Total250_20() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("J1", 90m, true),
                new Item("J2", 120m, true),
            };

            string? codigoCupon = null;
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(250.20m));
        }
        [Test]
        public void Test_LimiteEnvio_199_99_vs_200_00() 
        {
            // PRIMER CASO 199.99
            List<Item> productos_caso1 = new List<Item> 
            {
                new Item("X", 199.99m, false),
            };

            string? codigoCupon = null;
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado_caso1 = _calculadora.CalculateTotal(productos_caso1, codigoCupon, esVIP, enviarEmail); 


            Assert.That(resultado_caso1, Is.EqualTo(253.99m));

            // SEGUNDO CASO 200.00
            List<Item> productos_caso2 = new List<Item> 
            {
                new Item("Y", 200m, false),
            };

            string? codigoCupon_caso2 = null;
            bool esVIP_caso2 = false;
            bool enviarEmail_caso2 = false; 


            decimal resultado_caso2 = _calculadora.CalculateTotal(productos_caso2, codigoCupon_caso2, esVIP_caso2, enviarEmail_caso2);


            Assert.That(resultado_caso2, Is.EqualTo(224m));
        }
        [Test]
        public void Test_PrecioNegativo_LanzaArgumentException_ConNombreItem() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("Defectuoso", -5, false),
            };

            string? codigoCupon = null;
            bool esVIP = false;
            bool enviarEmail = false;


            var excepcion = Assert.Throws<ArgumentException>(() => 
            {
                _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);
            });


            Assert.That(excepcion.Message, Does.Contain("Defectuoso"));
        }
        [Test]
        public void Test_VipYPROMO10_DosItems_100_60_TotalesEsperados() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("A", 100m, false),
                new Item("B", 60m, false),
            };

            string? codigoCupon = "PROMO10";
            bool esVIP = true;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(182.32m));
        }
        [Test]
        public void Test_CuponInvalido_IgnoraDescuento_TotalSinCambios()
        {
            List<Item> productos = new List<Item>
            {
                new Item("X", 100m, false),
            };

            string? codigoCupon = "PROMO5";
            bool esVIP = false;
            bool enviarEmail = false;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(142m));
        }
        [Test]
        public void Test_Recibo_ImprimePalabrasClave_EnConsola()
        {
            List<Item> productos = new List<Item>
            {
                new Item("X", 100m, false),
            };
            string? codigoCupon = null;
            bool esVIP = false;
            bool enviarEmail = false;


            var escritorDeCadenas = new StringWriter();
            var consolaOriginal = Console.Out;
            Console.SetOut(escritorDeCadenas);

            string salidaCapturada = "";
            try
            {
                _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);
                salidaCapturada = escritorDeCadenas.ToString();
            }
            finally
            {
                Console.SetOut(consolaOriginal);
            }


            Assert.Multiple(() =>
            {
                Assert.That(salidaCapturada, Does.Contain("RECIBO"));
                Assert.That(salidaCapturada, Does.Contain("Subtotal:"));
                Assert.That(salidaCapturada, Does.Contain("TOTAL:"));
                Assert.That(salidaCapturada, Does.Contain("X"));
            });
        }
        [Test]
        public void Test_BanderaEmailVerdadera_ImprimeBloqueEmail() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("X", 100m, false),
            };
            string? codigoCupon = null;
            bool esVIP = false;
            bool enviarEmail = true;


            var escritorDeCadenas = new StringWriter();
            var consolaOriginal = Console.Out;
            Console.SetOut(escritorDeCadenas);

            string salidaCapturada = "";
            try
            {
                _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);
                salidaCapturada = escritorDeCadenas.ToString();
            }
            finally
            {
                Console.SetOut(consolaOriginal);
            }


            Assert.Multiple(() =>
            {
                Assert.That(salidaCapturada, Does.Contain("Enviando Email"));
                Assert.That(salidaCapturada, Does.Contain("cliente@example.com"));
                Assert.That(salidaCapturada, Does.Contain("Recibo de compra"));
            });
        }
        [Test]
        public void Test_Combinado_Fragil_Promo10_VIP_Email_Total224_44() 
        {
            List<Item> productos = new List<Item>
            {
                new Item("A", 120, true),
                new Item("B", 100, false),
            };

            string? codigoCupon = "PROMO10";
            bool esVIP = true;
            bool enviarEmail = true;


            decimal resultado = _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);


            Assert.That(resultado, Is.EqualTo(224.44m));



            var escritorDeCadenas = new StringWriter();
            var consolaOriginal = Console.Out;
            Console.SetOut(escritorDeCadenas);

            string salidaCapturada = "";
            try
            {
                _calculadora.CalculateTotal(productos, codigoCupon, esVIP, enviarEmail);
                salidaCapturada = escritorDeCadenas.ToString();
            }
            finally
            {
                Console.SetOut(consolaOriginal);
            }


            Assert.Multiple(() =>
            {
                Assert.That(salidaCapturada, Does.Contain("Enviando Email"));
                Assert.That(salidaCapturada, Does.Contain("cliente@example.com"));
                Assert.That(salidaCapturada, Does.Contain("Recibo de compra"));
            });
        }
    }
}