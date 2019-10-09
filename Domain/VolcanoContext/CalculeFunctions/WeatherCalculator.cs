using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VolcanoContext.CalculeFunctions
{
    public interface IWeatherCalculator
    {
        int CalculePosition(int num, int n);
        string GetWeather(int volcanoPosition, int betasoidePosition, int ferengiPosition);
    }
    public class WeatherCalculator : IWeatherCalculator
    {

        public int CalculePosition(int num, int n)
        {
            if (num == 0)
                return 0;
            if (num == 1)
                return n;

            return CalculePosition(num - 1, n) + n;
        }

        public int CalculeReversePosition(int num, int n)
        {
            return 0;
        }

        /// <summary>
        /// Verifica el clima de acuerdo a la posicion de cada planeta
        /// </summary>
        /// <param name="volcanoPosition"></param>
        /// <param name="betasoidePosition"></param>
        /// <param name="ferengiPosition"></param>
        /// <returns></returns>
        public string GetWeather(int volcanoPosition, int betasoidePosition, int ferengiPosition)
        {
            /*
             * SEQUIA
             * Para estos periodos, es necesario que los planetas Betasoite y Ferengi esten alineados con el planeta Volcano. 
             * Eso es decir, que en el mismo dia, los 3 planetas tengan el mismo grado de posicion.
             */
            if (volcanoPosition == betasoidePosition && volcanoPosition == ferengiPosition)
            {
                return "Sequia";
            }

            /*
             * LLUVIA
             * Para los periodos de lluvia, los 3 planetas tienen que formar un triangulo con sus respectivas posiciones. 
             * Eso quiere decir, si dividimos la orbita circular en 3 (De 0° a 120° - De 120° a 270° - De 270° a 360°), 
             * cada planeta tiene que estar posicionado en cuadrantes distintos.
             */
            switch (volcanoPosition)
            {
                // cuando volcano esta en la primera parte - 1/3
                case int n when (n < 120):
                    //Volcano - 1/3 - Betasoide - 2/3 - Ferengi - 3/3
                    if (betasoidePosition > 120 && betasoidePosition < 240)
                    {
                        if (ferengiPosition > 240)
                            return "Lluvia";
                    }
                    else
                    {   //Volcano - 1/3 - Betasoide - 3/3 - Ferengi - 2/3
                        if (betasoidePosition > 240)
                        {
                            if (ferengiPosition > 120 && ferengiPosition < 240)
                            {
                                return "Lluvia";
                            }
                        }
                    }
                    break;

                // cuando volcano esta en la segunda parte - 2/3
                case int n when (n > 120 && n < 240):
                    //Volcano - 2/3 - Betasoide - 1/3 - Ferengi - 3/3
                    if (betasoidePosition < 120)
                    {
                        if (ferengiPosition > 240)
                        {
                            return "Lluvia";
                        }
                    }
                    else
                    { //Volcano - 2/3 - Betasoide - 3/3 - Ferengi - 1/3
                        if (betasoidePosition > 240)
                        {
                            if (ferengiPosition < 120)
                            {
                                return "Lluvia";
                            }
                        }
                    }
                    break;

                // cuando volcano esta en la ultima parte - 3/3
                default:
                    //Volcano - 3/3 - Betasoide - 1/3 - Ferengi - 2/3
                    if (betasoidePosition < 120)
                    {
                        if (ferengiPosition > 120 && ferengiPosition < 240)
                        {
                            return "Lluvia";
                        }
                    }
                    else
                    { //Volcano - 3/3 - Betasoide - 2/3 - Ferengi - 1/3
                        if (betasoidePosition > 120 && betasoidePosition < 240)
                        {
                            if (ferengiPosition < 120)
                            {
                                return "Lluvia";
                            }
                        }
                    }
                    break;
            }

            /*
             * OPTIMAS CONDICIONES
             * Para los periodos de optimas condiciones, los planetas tienen que estar alineados en una linea recta. 
             * Para eso, Es necesario que dos planetas tengan el mismo grado de posicion y el tercer planeta tenga la misma 
             * posicion + o - 180° (Se suma cuando los dos planetas tienen grados menores a 180 y se resta cuando son mayores 
             * a 180.
             */
            if (volcanoPosition == betasoidePosition)
            {
                if (volcanoPosition < 180)
                {
                    if (volcanoPosition == (ferengiPosition + 180))
                        return "Optimas Condiciones";
                }
                else
                {
                    if (volcanoPosition == (ferengiPosition - 180))
                        return "Optimas Condiciones";
                }

            }

            if (volcanoPosition == ferengiPosition)
            {
                if (volcanoPosition < 180)
                {
                    if (volcanoPosition == (betasoidePosition + 180))
                        return "Optimas Condiciones";
                }
                else
                {
                    if (volcanoPosition == (betasoidePosition - 180))
                        return "Optimas Condiciones";
                }
            }

            if (ferengiPosition == betasoidePosition)
            {
                if (volcanoPosition < 180)
                {
                    if (volcanoPosition == (volcanoPosition + 180))
                        return "Optimas Condiciones";
                }
                else
                {
                    if (volcanoPosition == (volcanoPosition - 180))
                        return "Optimas Condiciones";
                }
            }

            return "Dia nublado";
        }
    }
}
