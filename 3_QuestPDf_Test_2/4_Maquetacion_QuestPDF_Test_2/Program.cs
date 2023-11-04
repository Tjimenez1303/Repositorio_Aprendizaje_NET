// Importamos QuestPDF 
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Margin(30); // Ponemos un margen al header

        page.Header().ShowOnce().Row(row =>
        {
            // Fila 1 del Header
            row
                .RelativeItem()
                .Height(60)
                .Column(col =>
                {
                    col
                        .Item()
                        .Text("Invoice #5597").Bold().FontSize(20);

                    col
                        .Item()
                        .Text(txt =>
                        {
                            txt.Span("Issue date: ").FontSize(10);
                            txt.Span("25.10.2020").FontSize(10);
                        });

                    col
                        .Item()
                        .Text(txt =>
                        {
                            txt.Span("Due date: ").FontSize(10);
                            txt.Span("08.11.2020").FontSize(10);
                        });

                });

            // Fila 2 del header
            row
                .ConstantItem(100)  // Crear un item en que el tamaño sea proporcional en todos || ConstantItem() -> Fijar el ancho de esa columna
                //.Border(1) // Pone un borde de 1 a la columna
                .Height(40) // Alto de 60 px
                .Placeholder();
        });

        // Contenido de la página || .PaddingVertical(10) -> Para separar un poco el contenido del header
        page.Content().PaddingVertical(10).Column(col1 =>
        {
            // Fila 1: Semitabla de From y For
            col1
            .Item()
            .Row(row1 =>
            {
                // Columna 1: From
                row1
                .RelativeItem()
                .Column(col1 =>
                {
                    // Texto de From
                    col1
                    .Item()
                    .Text("From");

                    // Linea horizontal
                    col1
                    .Item()
                    .LineHorizontal(2);

                    /************* Filas: Semitabla ******/
                    col1
                    .Item()
                    .PaddingVertical(2)
                    .Text("Perspiciatis Veritatis");

                    col1
                    .Item()
                    .PaddingVertical(2)
                    .Text("Ipsa tempore");

                    col1
                    .Item()
                    .PaddingVertical(2)
                    .Text("Illum sed minima Ratione quia illum");

                    col1
                    .Item()
                    .PaddingVertical(2)
                    .Text("consequuntur81@voluptatem.com");

                    col1
                    .Item()
                    .PaddingVertical(2)
                    .Text("216-974-7107");

                });

                // Agregamos un espacio de separación entre las dos columnas
                row1.Spacing(60);


                // Columna 2: For
                row1
               .RelativeItem()
               .Column(col1 =>
               {
                   // Texto de For
                   col1
                   .Item()
                   .Text("For");

                   // Linea horizontal
                   col1
                   .Item()
                   .LineHorizontal(2);

                   /************* Filas: Semitabla ******/
                   col1
                   .Item()
                   .PaddingVertical(2)
                   .Text("Perspiciatis Veritatis");

                   col1
                   .Item()
                   .PaddingVertical(2)
                   .Text("Ipsa tempore");

                   col1
                   .Item()
                   .PaddingVertical(2)
                   .Text("Illum sed minima Ratione quia illum");

                   col1
                   .Item()
                   .PaddingVertical(2)
                   .Text("consequuntur81@voluptatem.com");

                   col1
                   .Item()
                   .PaddingVertical(2)
                   .Text("216-974-7107");

               });

            });

            // Agregamos un espacio de separación entre las dos filas
            col1.Spacing(10);

            // Acumulador para el máximo total
            double maxTotal = 0;

            // Fila 2: Tabla de datos
            col1
            .Item()
            .Table(table =>
            {
                // Defino el número de columnas que tendrá la tabla
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(0.3f);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                // Defino los encabezados de la tabla
                table.Header(header =>
                {
                    // Header 1: Id
                    header
                        .Cell()
                        .BorderBottom(1)
                        .Padding(2)
                        .Text("#");

                    // Header 2: Nombre del producto
                    header
                        .Cell()
                        .BorderBottom(1)
                        .Padding(2)
                        .Text("Product");
                    
                    // Header 3: Precio por unidad
                    header
                        .Cell()
                        .BorderBottom(1)
                        .Padding(2)
                        .Text("Unit price");
                    
                    // Header 4: Cantidad
                    header
                        .Cell()
                        .BorderBottom(1)
                        .Padding(2)
                        .Text("Quantity");
                    
                    // Header 5: Total
                    header
                        .Cell()
                        .BorderBottom(1)
                        .Padding(2)
                        .Text("Total");
                });


                // Campos de la tabla
                foreach (var id in Enumerable.Range(1,9))
                {
                    var cantidad = Placeholders.Random.Next(1, 10);
                    var precio = Placeholders.Random.NextDouble() * (60 - 10) + 10;
                    var total = cantidad * precio;

                    table
                        .Cell()
                        .BorderBottom(0.5f)
                        .BorderBottom(1)
                        .BorderColor("#c6c6c7")
                        .Padding(1.5f)
                        .Text(id.ToString()).FontSize(10);
                    
                    table
                        .Cell()
                        .BorderBottom(0.5f)
                        .BorderBottom(1)
                        .BorderColor("#c6c6c7")
                        .Padding(1.5f)
                        .Text(Placeholders.Label()).FontSize(10);
                    
                    table
                        .Cell()
                        .BorderBottom(1)
                        .BorderColor("#c6c6c7")
                        .AlignRight()
                        .Padding(1.5f)
                        .Text($"{Math.Round(precio,2)} $").FontSize(10);
                    
                    table
                        .Cell()
                        .BorderBottom(1)
                        .BorderColor("#c6c6c7")
                        .Padding(1.5f)
                        .AlignRight()
                        .Text(cantidad.ToString()).FontSize(10);
                    
                    table
                        .Cell()
                        .BorderBottom(1)
                        .BorderColor("#c6c6c7")
                        .Padding(1.5f)
                        .AlignRight()
                        .Text($"{Math.Round(total,2)} $").FontSize(10);

                    maxTotal += total;
                }

            });

            // Fila 3: Total 
            col1
                .Item()
                .AlignRight()
                .Text($"Grand Total: {Math.Round(maxTotal, 2)} $").FontSize(12);

            // Fila 4: Comentarios
            col1
                .Item()
                .Background(Colors.Grey.Lighten2)
                .Padding(10)
                .Column(column =>
                {
                    // Para separar entre cada columna de col1
                    column.Spacing(5);

                    column
                        .Item()
                        .Text("Comments")
                        .FontSize(14);

                    column
                        .Item()
                        .Text(Placeholders.LoremIpsum());

                });
        });

        // Footer de la página
        page.Footer().AlignCenter().Text(text =>
        {
            text.Span("Page ").FontSize(10);
            text.CurrentPageNumber().FontSize(10); // Para poner la página en la que va
        });

    });
}).ShowInPreviewer();
