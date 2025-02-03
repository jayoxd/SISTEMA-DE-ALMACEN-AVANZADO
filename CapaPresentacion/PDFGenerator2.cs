using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

public class PDFGenerator2
{
    // Método principal para generar el comprobante de salida
    public void GenerarComprobanteSalida(string nroDocumento, string rutaArchivo)
    {
        // Obtener los datos de la salida y detalle desde la base de datos
        DataSet datosSalida = ObtenerSalidaConDetalles(nroDocumento); // Llamada al método de la capa de datos
        DataTable salida = datosSalida.Tables[0]; // Información principal de la salida
        DataTable detalles = datosSalida.Tables[1]; // Detalles de los productos

        // Crear el documento PDF
        Document doc = new Document(PageSize.A4);
        PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));

        // Abrir el documento
        doc.Open();

        // Título de la Factura
        Paragraph titulo = new Paragraph("COMPROBANTE DE SALIDA", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
        titulo.Alignment = Element.ALIGN_CENTER;
        doc.Add(titulo);

        // Espacio
        doc.Add(new Paragraph("\n"));

        // Crear una tabla con 2 columnas: una para los datos de la empresa y otra para el logo
        PdfPTable headerTable = new PdfPTable(2);
        headerTable.WidthPercentage = 100;
        headerTable.SetWidths(new float[] { 6f, 3f }); // Ajustamos las proporciones de las columnas

        // Celda para los datos de la empresa (izquierda)
        PdfPCell empresaInfoCell = new PdfPCell();
        empresaInfoCell.AddElement(new Paragraph($"Código de Salida: {salida.Rows[0]["NroDocumento"]}"));
        empresaInfoCell.AddElement(new Paragraph($"Cliente: {salida.Rows[0]["ClienteNombre"]}"));
        empresaInfoCell.AddElement(new Paragraph($"Medio: {salida.Rows[0]["Medio"]}"));
        empresaInfoCell.AddElement(new Paragraph($"Tipo Comprobante: {salida.Rows[0]["Tipo_Comprobante"]}"));
        empresaInfoCell.Border = 0;  // Sin borde
        empresaInfoCell.VerticalAlignment = Element.ALIGN_TOP; // Alineación vertical arriba
        empresaInfoCell.HorizontalAlignment = Element.ALIGN_LEFT; // Alineación a la izquierda
        headerTable.AddCell(empresaInfoCell);

        // Celda para el logo (derecha)
        PdfPCell logoCell = new PdfPCell();
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Especificar el nombre completo del recurso
        string resourceName = "CapaPresentacion.Imagenes.LANMEITRANSP.png";

        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream != null)
            {
                Image logo = Image.GetInstance(stream);
                logo.ScaleToFit(100f, 100f); // Ajusta el tamaño de la imagen
                logo.Alignment = Element.ALIGN_RIGHT; // Alineación a la derecha
                logoCell.AddElement(logo); // Agregar el logo
            }
            else
            {
                MessageBox.Show("No se encontró el recurso de la imagen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        logoCell.Border = 0;  // Sin borde
        logoCell.VerticalAlignment = Element.ALIGN_TOP; // Alineación vertical arriba
        logoCell.HorizontalAlignment = Element.ALIGN_RIGHT; // Alineación horizontal a la derecha
        headerTable.AddCell(logoCell);

        // Añadir la tabla de encabezado con el logo y los datos de la empresa
        doc.Add(headerTable);

        // Crear tabla para los datos de "Fecha Entrada", "Tipo Cambio", "Número Comprobante" y "Fecha Emisión"
        PdfPTable infoTable = new PdfPTable(2);  // Dos columnas
        infoTable.WidthPercentage = 100;

        // Fecha Entrada y Número Comprobante en una fila
        PdfPCell fechaEntradaCell = new PdfPCell(new Phrase($"Fecha Salida: {salida.Rows[0]["Fecha"]:dd/MM/yyyy}", new Font(Font.FontFamily.HELVETICA, 12)));
        fechaEntradaCell.HorizontalAlignment = Element.ALIGN_LEFT;
        fechaEntradaCell.Border = 0;  // Sin borde
        infoTable.AddCell(fechaEntradaCell);

        PdfPCell numeroComprobanteCell = new PdfPCell(new Phrase($"Número Comprobante: {salida.Rows[0]["Nro_Comprobante"]}", new Font(Font.FontFamily.HELVETICA, 12)));
        numeroComprobanteCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        numeroComprobanteCell.Border = 0;  // Sin borde
        infoTable.AddCell(numeroComprobanteCell);

        // Tipo Cambio y Fecha Emisión en una fila
        PdfPCell tipoCambioCell = new PdfPCell(new Phrase($"Tipo de Venta: {salida.Rows[0]["TipoVenta"]}", new Font(Font.FontFamily.HELVETICA, 12)));  // Ajuste al campo TipoVenta
        tipoCambioCell.HorizontalAlignment = Element.ALIGN_LEFT;
        tipoCambioCell.Border = 0;  // Sin borde
        infoTable.AddCell(tipoCambioCell);

        PdfPCell fechaEmisionCell = new PdfPCell(new Phrase($"Fecha Emisión: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}", new Font(Font.FontFamily.HELVETICA, 12)));
        fechaEmisionCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        fechaEmisionCell.Border = 0;  // Sin borde
        infoTable.AddCell(fechaEmisionCell);

        // Añadir la tabla con la información a la izquierda y derecha
        doc.Add(infoTable);

        // Espacio
        doc.Add(new Paragraph("\n"));

        // Crear la tabla de detalles de los productos
        PdfPTable tabla = new PdfPTable(7); // Agregar columnas para los nuevos campos
        tabla.WidthPercentage = 100;
        tabla.SetWidths(new float[] { 3f, 6f, 3f, 3f, 3f, 3f, 3f }); // Definir el tamaño de las columnas

        // Encabezados de la tabla
        tabla.AddCell(CreateHeaderCell("Código Producto"));
        tabla.AddCell(CreateHeaderCell("Descripción Producto"));
        tabla.AddCell(CreateHeaderCell("Precio Compra"));
        tabla.AddCell(CreateHeaderCell("Precio Venta"));
        tabla.AddCell(CreateHeaderCell("Cantidad"));
        tabla.AddCell(CreateHeaderCell("Importe"));
        tabla.AddCell(CreateHeaderCell("Ganancia"));

        decimal totalImporte = 0;
        decimal totalGanancia = 0;

        foreach (DataRow fila in detalles.Rows)
        {
            tabla.AddCell(fila["CodigoProducto"].ToString());
            tabla.AddCell(fila["DescripcionProducto"].ToString());

            // PrecioCompra
            PdfPCell precioCompraCell = new PdfPCell(new Phrase(Convert.ToDecimal(fila["Precio"]).ToString("S/. 0.00")));
            precioCompraCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(precioCompraCell);

            // PrecioVenta
            PdfPCell precioVentaCell = new PdfPCell(new Phrase(Convert.ToDecimal(fila["PrecioVendido"]).ToString("S/. 0.00")));
            precioVentaCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(precioVentaCell);

            // Cantidad
            PdfPCell cantidadCell = new PdfPCell(new Phrase(fila["Cantidad"].ToString()));
            cantidadCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(cantidadCell);

  
            // Importe = PrecioVendido * Cantidad
            decimal importe = Convert.ToInt32(fila["Cantidad"]) * Convert.ToDecimal(fila["PrecioVendido"]);
            totalImporte += importe;

            PdfPCell importeCell = new PdfPCell(new Phrase(importe.ToString("S/. 0.00")));
            importeCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(importeCell);

            // Ganancia
            decimal ganancia = Convert.ToDecimal(fila["Ganancia"]);
            totalGanancia += ganancia;

            PdfPCell gananciaCell = new PdfPCell(new Phrase(ganancia.ToString("S/. 0.00")));
            gananciaCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(gananciaCell);
        }

        // Añadir la tabla al documento
        doc.Add(tabla);

        // Añadir los totales al final de la tabla
        doc.Add(new Paragraph("\n"));
        Paragraph totalImporteText = new Paragraph($"Total Importe: S/. {totalImporte.ToString("0.00")}", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
        totalImporteText.Alignment = Element.ALIGN_RIGHT;
        doc.Add(totalImporteText);

        Paragraph totalGananciaText = new Paragraph($"Total Ganancia: S/. {totalGanancia.ToString("0.00")}", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
        totalGananciaText.Alignment = Element.ALIGN_RIGHT;
        doc.Add(totalGananciaText);

        // Espacio al final de la factura
        doc.Add(new Paragraph("\n"));

        // Comentarios
        Paragraph comentarios = new Paragraph("Gracias por su confianza", new Font(Font.FontFamily.HELVETICA, 12));
        comentarios.Alignment = Element.ALIGN_CENTER;
        doc.Add(comentarios);

        // Cerrar el documento
        doc.Close();

        // Informar al usuario que el PDF fue generado
        Console.WriteLine("Comprobante generado correctamente en: " + rutaArchivo);
    }

    // Método para obtener los datos completos de la salida y los detalles
    private DataSet ObtenerSalidaConDetalles(string nroDocumento)
    {
        // Aquí se utiliza el método de la capa de datos que ya tienes:
        N_Salida datos = new N_Salida();
        return datos.ObtenerSalidaConDetalles(nroDocumento);
    }

    // Método auxiliar para crear las celdas de los encabezados de la tabla
    private PdfPCell CreateHeaderCell(string text)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD,BaseColor.WHITE)));
        cell.BackgroundColor = new BaseColor(11, 62, 92); // Azul oscuro
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Padding = 5;
        return cell;
    }
}
