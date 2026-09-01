using System.IO;
using System.Globalization;

class LectorDatos
{
    // Lee el archivo u.data y devuelve un arreglo de RatingRecord
    // en el mismo orden en que aparecen en el archivo.
    public static RatingRecord[] LeerArchivo(string rutaArchivo)
    {
        string[] lineas = File.ReadAllLines(rutaArchivo);

        RatingRecord[] registros = new RatingRecord[lineas.Length];

        for (int i = 0; i < lineas.Length; i++)
        {
            // Cada línea viene separada por tabulador:
            // userId \t movieId \t rating \t timestamp
            string[] partes = lineas[i].Split('\t');

            int userId = int.Parse(partes[0]);
            int movieId = int.Parse(partes[1]);
            int rating = int.Parse(partes[2]);
            long timestamp = long.Parse(partes[3]);

            // El RecordId lo asignamos nosotros al leer cada fila (0, 1, 2...)
            int recordId = i;

            registros[i] = new RatingRecord(recordId, userId, movieId, rating, timestamp);
        }

        return registros;
    }

    // Escribe la lista de mediciones a un archivo CSV, con una fila
    // por cada Medicion, tal como pide el punto 11 del enunciado.
    public static void EscribirCsv(List<Medicion> mediciones, string rutaArchivo)
    {
        using (StreamWriter escritor = new StreamWriter(rutaArchivo))
        {
            // Encabezado exacto que pide el punto 11
            escritor.WriteLine("Structure,Operation,N,Repetition,ElapsedTicks,MicrosecondsPerOp,Checksum");

            foreach (Medicion m in mediciones)
            {
                escritor.WriteLine(
                    m.Structure + "," +
                    m.Operation + "," +
                    m.N + "," +
                    m.Repetition + "," +
                    m.ElapsedTicks + "," +
                    m.MicrosecondsPerOp.ToString(CultureInfo.InvariantCulture) + "," +
                    m.Checksum
                );
            }
        }
    }
}