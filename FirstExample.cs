/*
Console.WriteLine("Generando archivo Excel");
using (var workbook = new XLWorkbook())
{
    var worksheet = workbook.Worksheets.Add("Hoja1");
    worksheet.Cell(1, 1).Value = "Nombre";
    worksheet.Cell(1, 2).Value = "Edad";
    worksheet.Cell(2, 1).Value = "Juan";
    worksheet.Cell(2, 2).Value = 28;
    workbook.SaveAs(@"C:\Users\Jjmac\OneDrive\Documentos\Escaneadas\archivoPrueba.xlsx");
}
Console.WriteLine("El archivo Excel ha sido creado correctamente!");
*/

/*
Console.WriteLine("Modificando un excel");

string rutaArchivo = @"C:\Users\Jjmac\OneDrive\Documentos\Escaneadas\archivoPrueba.xlsx";

using (var workbook = new XLWorkbook(rutaArchivo))
{
    var worksheet = workbook.Worksheet(1);
    worksheet.Cell(2, 2).Value = 30;
    workbook.Save();
}

Console.WriteLine("Archivo modificado exitosamente!");
*/

/*
Console.WriteLine("Generando tabla de Excel");
using (var workbook = new XLWorkbook())
{
    var worksheet = workbook.Worksheets.Add("Datos");
    // Esto agrega datos a una tabla
    worksheet.Cell(1, 1).Value = "ID";
    worksheet.Cell(1, 2).Value = "Nombre";
    worksheet.Cell(1, 3).Value = "Edad";
    
    worksheet.Cell(2, 1).Value = 1;
    worksheet.Cell(2, 2).Value = "Juan";
    worksheet.Cell(2, 3).Value = 28;
    
    worksheet.Cell(3, 1).Value = 2;
    worksheet.Cell(3, 2).Value = "Maria";
    worksheet.Cell(3, 3).Value = 34;
    
    // Crear una tabla con los gatos
    var range = worksheet.Range("A1:C3");
    range.CreateTable();
    
    //Aqui es donde guardas el archivo generado
    workbook.SaveAs(@"C:\Users\Jjmac\OneDrive\Documentos\Escaneadas\Tabla_de_Prueba.xlsx");
}
Console.WriteLine("La tabla excel se creo por ahi!");
*/

/*
Console.WriteLine("Decorando tabla de Excel");
using (var workbook = new XLWorkbook())
{
    var worksheet = workbook.Worksheets.Add("Datos");
    
    //Esto aplica un fornato a la 1ra fila
    var headerRow = worksheet.Row(1);
    headerRow.Style.Font.Bold = true;
    headerRow.Style.Fill.BackgroundColor = XLColor.Cyan;
    headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
    
    // Esto agrega datos
    worksheet.Cell(1, 1).Value = "ID";
    worksheet.Cell(1, 2).Value = "Nombre";
    worksheet.Cell(1, 3).Value = "Edad";
    
    worksheet.Cell(2, 1).Value = 1;
    worksheet.Cell(2, 2).Value = "Juan";
    worksheet.Cell(2, 3).Value = 28;
    
    // Crear una tabla con los gatos
    var range = worksheet.Range("A1:C3");
    range.CreateTable();
    
    //Aqui es donde guardas el archivo decorado
    workbook.SaveAs(@"C:\Users\Jjmac\OneDrive\Documentos\Escaneadas\Tabla_decorada.xlsx");
}
Console.WriteLine("La tabla ya se decoro!");
*/