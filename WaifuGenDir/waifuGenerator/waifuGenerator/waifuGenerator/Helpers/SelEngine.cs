using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waifuGenerator.Helpers
{
    internal class SelEngine
    {
        public SelEngine()
        {
            //SeleniumManager sel = SeleniumManager.Cr
            // Ruta al ejecutable del controlador de Chrome
            var driverPath = @"<ruta_al_directorio_del_controlador_de_Chrome>";

            // Inicializar el controlador de Chrome
            var driver = new ChromeDriver(driverPath);

            // Navegar a la página web
            driver.Navigate().GoToUrl("https://www.openiapony.com");

            // Encontrar el botón de inicio de sesión por su clase o por su texto
            // Por ejemplo, si el botón tiene la clase "login-btn", puedes encontrarlo así:
            // var loginButton = driver.FindElement(By.ClassName("login-btn"));
            // O si el botón tiene el texto "Login":
            var loginButton = driver.FindElement(By.XPath("//button[text()='Login']"));

            // Hacer clic en el botón de inicio de sesión
            loginButton.Click();

            // Cerrar el navegador
            driver.Quit();
        }

    }
}
