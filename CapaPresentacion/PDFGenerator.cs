using CapaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

public class PDFGenerator
{
    // Método principal para generar el comprobante

    public void GenerarComprobanteEntrada(string nroDocumento, string rutaArchivo)
    {
        // Obtener los datos de la entrada y detalle desde la base de datos
        DataSet datosEntrada = ObtenerEntradaConDetalles(nroDocumento); // Llamada al método de la capa de datos
        DataTable entrada = datosEntrada.Tables[0]; // Información principal de la entrada
        DataTable detalles = datosEntrada.Tables[1]; // Detalles de los productos

        // Crear el documento PDF
        Document doc = new Document(PageSize.A4);
        PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));

        // Abrir el documento
        doc.Open();

        // Título de la Factura
        Paragraph titulo = new Paragraph("COMPROBANTE DE ENTRADA", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
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
        empresaInfoCell.AddElement(new Paragraph($"Codigo de Entrada: {entrada.Rows[0]["NroDocumento"]}"));
        empresaInfoCell.AddElement(new Paragraph($"RUC: {entrada.Rows[0]["RUC"]}"));
        empresaInfoCell.AddElement(new Paragraph($"Proveedor: {entrada.Rows[0]["Nombre"]}"));
        empresaInfoCell.AddElement(new Paragraph($"Tipo Comprobante: {entrada.Rows[0]["Tipo_Comprobante"]}"));
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
        PdfPCell fechaEntradaCell = new PdfPCell(new Phrase($"Fecha Entrada: {entrada.Rows[0]["Fecha"]:dd/MM/yyyy}", new Font(Font.FontFamily.HELVETICA, 12)));
        fechaEntradaCell.HorizontalAlignment = Element.ALIGN_LEFT;
        fechaEntradaCell.Border = 0;  // Sin borde
        infoTable.AddCell(fechaEntradaCell);

        PdfPCell numeroComprobanteCell = new PdfPCell(new Phrase($"Número Comprobante: {entrada.Rows[0]["Nro_Comprobante"]}", new Font(Font.FontFamily.HELVETICA, 12)));
        numeroComprobanteCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        numeroComprobanteCell.Border = 0;  // Sin borde
        infoTable.AddCell(numeroComprobanteCell);

        // Tipo Cambio y Fecha Emisión en una fila
        PdfPCell tipoCambioCell = new PdfPCell(new Phrase($"Tipo Cambio: {entrada.Rows[0]["TipoCambio"]}", new Font(Font.FontFamily.HELVETICA, 12)));
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
        PdfPTable tabla = new PdfPTable(5);
        tabla.WidthPercentage = 100;
        tabla.SetWidths(new float[] { 3f, 6f, 3f, 3f, 3f });

        // Encabezados de la tabla
        tabla.AddCell(CreateHeaderCell("Código Producto"));
        tabla.AddCell(CreateHeaderCell("Descripción Producto"));
        tabla.AddCell(CreateHeaderCell("Precio Compra"));
        tabla.AddCell(CreateHeaderCell("Cantidad"));
        tabla.AddCell(CreateHeaderCell("Importe"));

        foreach (DataRow fila in detalles.Rows)
        {
            tabla.AddCell(fila["CodigoProducto"].ToString());
            tabla.AddCell(fila["DescripcionProducto"].ToString());

            // Crear celda para PrecioCompra y centrarla
            decimal precioCompra = Convert.ToDecimal(fila["PrecioCompra"]);
            string precioCompraFormato = precioCompra == 0 ? "$0" : precioCompra.ToString("S/. 0.0");
            PdfPCell precioCompraCell = new PdfPCell(new Phrase(precioCompraFormato));
            precioCompraCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(precioCompraCell);

            // Crear celda para Cantidad y centrarla
            PdfPCell cantidadCell = new PdfPCell(new Phrase(fila["Cantidad"].ToString()));
            cantidadCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(cantidadCell);

            // Calcular el importe
            decimal importe = Convert.ToInt32(fila["Cantidad"]) * precioCompra;
            string importeFormato = importe == 0 ? "$0" : importe.ToString("S/. 0.0");

            // Crear celda para Importe y centrarla
            PdfPCell importeCell = new PdfPCell(new Phrase(importeFormato));
            importeCell.HorizontalAlignment = Element.ALIGN_CENTER; // Centrado
            tabla.AddCell(importeCell);
        }

        // Añadir la tabla al documento
        doc.Add(tabla);

        // Calcular el total de la factura
        decimal totalFactura = 0;
        foreach (DataRow fila in detalles.Rows)
        {
            totalFactura += Convert.ToInt32(fila["Cantidad"]) * Convert.ToDecimal(fila["PrecioCompra"]);
        }

        // Espacio para el total
        doc.Add(new Paragraph("\n"));
        Paragraph totalText = new Paragraph($"TOTAL: S/. {totalFactura.ToString("0.00")}", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
        totalText.Alignment = Element.ALIGN_RIGHT;
        doc.Add(totalText);

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
        // Abrir el archivo PDF automáticamente
        try
        {
            // Usar Process.Start para abrir el archivo PDF con el programa predeterminado
            System.Diagnostics.Process.Start(rutaArchivo);
        }
        catch (Exception ex)
        {
            // Manejar cualquier error que pueda ocurrir al intentar abrir el archivo
            Console.WriteLine("Error al intentar abrir el archivo PDF: " + ex.Message);
        }

    }


    // Método para obtener los datos completos de la entrada y los detalles
    private DataSet ObtenerEntradaConDetalles(string nroDocumento)
    {
        // Aquí se utiliza el método de la capa de datos que ya tienes:
        N_Entrada datos = new N_Entrada();
        return datos.ObtenerEntradaConDetalles(nroDocumento);
    }

    // Método auxiliar para crear las celdas de los encabezados de la tabla
    private PdfPCell CreateHeaderCell(string text)
    {
        PdfPCell cell = new PdfPCell(new Phrase(text, new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD, BaseColor.WHITE)));
        cell.BackgroundColor = new BaseColor(11, 62, 92); // Verde oscuro
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.Padding = 5;
        return cell;
    }
}
