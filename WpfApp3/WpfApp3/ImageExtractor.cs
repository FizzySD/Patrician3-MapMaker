using System;
using System.Drawing;

namespace WpfApp3
{
    internal class ImageExtractor
    {
        public void ConvertImage()
        {
            string inputImagePath = "output.bmp";
            string outputImagePath = "nav_matrix.bmp"; // Cambiato il nome del file di output

            // Carica l'immagine BMP
            using (Bitmap inputImage = new Bitmap(inputImagePath))
            {
                // Modifica i pixel vuoti (trasparenti) impostandoli a nero
                ModifyTransparentPixels(inputImage);

                // Salva l'immagine modificata in un nuovo file
                inputImage.Save(outputImagePath);

                Console.WriteLine("Immagine modificata salvata con successo.");
            }
        }

        public void ModifyTransparentPixels(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    // Ottieni il colore del pixel corrente
                    Color pixelColor = image.GetPixel(x, y);

                    // Verifica se il pixel è completamente vuoto (trasparente)
                    if (pixelColor.A == 0)
                    {
                        // Imposta il pixel a nero
                        image.SetPixel(x, y, Color.Black);
                    }
                }
            }
        }
    }
}
