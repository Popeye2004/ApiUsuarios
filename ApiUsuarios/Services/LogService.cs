using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiUsuarios.Services
{
    public class LogService
    {
        private readonly string _rutaArchivo;

        public LogService(string rutaArchivo = "Logs/usuarios_log.json")
        {
            _rutaArchivo = rutaArchivo;
            var directorio = Path.GetDirectoryName(_rutaArchivo);
            if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }
        }

        public async Task AgregarLogAsync(object entrada)
        {
            try
            {
                List<object> logs = new List<object>();

                if (File.Exists(_rutaArchivo))
                {
                    var contenidoExistente = await File.ReadAllTextAsync(_rutaArchivo);
                    if (!string.IsNullOrWhiteSpace(contenidoExistente))
                    {
                        logs = JsonSerializer.Deserialize<List<object>>(contenidoExistente) ?? new List<object>();
                    }
                }

                var logEntry = new
                {
                    Fecha = DateTime.UtcNow,
                    Datos = entrada
                };
                logs.Add(logEntry);

                var opciones = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(logs, opciones);
                await File.WriteAllTextAsync(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir el log: {ex.Message}");
            }
        }

        public async Task<List<object>> ObtenerLogsAsync()
        {
            try
            {
                if (!File.Exists(_rutaArchivo))
                    return new List<object>();

                var contenido = await File.ReadAllTextAsync(_rutaArchivo);
                if (string.IsNullOrWhiteSpace(contenido))
                    return new List<object>();

                return JsonSerializer.Deserialize<List<object>>(contenido) ?? new List<object>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el log: {ex.Message}");
                return new List<object>();
            }
        }
    }
}