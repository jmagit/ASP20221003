using System.ComponentModel.DataAnnotations;

namespace Microsersicios {
    /// <summary>
    /// Pronóstico del tiempo
    /// </summary>
    public class WeatherForecast {
        public DateTime Date { get; set; }
        /// <summary>
        /// Temperatura en grados Celsius
        /// </summary>
        public int TemperatureC { get; set; }
        /// <summary>
        /// Temperatura en grados Fahrenheit
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// Resumen
        /// </summary>
        /// 
        [StringLength(maximumLength: 100)]
        public string? Summary { get; set; }
    }
}