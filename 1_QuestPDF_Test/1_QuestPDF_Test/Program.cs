using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// code in your main method
Document.Create(container =>
{
    container.Page(page =>
    {
        /***********************************DEMOSTRACIÓN 1***********************************/
        //// Header de la pagina
        ///*
        // * Height(100): Ocuparemos 100 px de Header
        // * Background(Colors.Blue.Medium): Pintamos de color azul 
        // */
        //page.Header().Height(100).Background(Colors.Blue.Medium);


        //// Contenido de la pagina
        ///*
        // * Background(Colors.Yellow.Medium): Pintamos de color amarillo completamente 
        // */
        //page.Content().Background(Colors.Yellow.Medium);

        //// Footer de la pagina
        ///*
        // * Height(50): Ocuparemos 50 px de Header
        // * Background(Colors.Red.Medium): Pintamos de color rojo
        // */
        //page.Footer().Height(50).Background(Colors.Red.Medium);

        /***********************************DEMOSTRACIÓN 2 ***********************************/

        page.Margin(30); // Ponemos un margen al header

        // Header de la pagina
        page.Header().ShowOnce().Row(row =>
        {
            /*************************** EJEMPLO DE USO ROW *********************************/
            //    // Columna 1 del header
            //    row
            //        .RelativeItem()   // Crear un item en que el tamaño sea proporcional en todos || ConstantItem() -> Fijar el ancho de esa columna
            //        .Border(1)       // Pone un borde negro a la columna 
            //        .Background(Colors.Green.Medium) // Color verde
            //        .Height(100);                     // Alto de 100

            //    // Columna 2 del header
            //    row
            //        .RelativeItem()
            //        .Border(1)
            //        .Background(Colors.Red.Medium)
            //        .Height(100);

            //    // Columna 3 del header
            //    row
            //        .RelativeItem()
            //        .Border(1)
            //        .Background(Colors.Yellow.Medium)
            //        .Height(100);



            /*************************** APLICANDO EL USO ********************************************/

            // Fila 1 del header
            row
                .ConstantItem(140)  // Crear un item en que el tamaño sea proporcional en todos || ConstantItem() -> Fijar el ancho de esa columna
                .Border(1) // Pone un borde de 1 a la columna
                .Height(60) // Alto de 60 px
                .Placeholder();

            // Fila 2 del header
            row
                .RelativeItem()
                .Column(col =>
                {
                    col
                        .Item() // Agreagamos un item o fila dentro de la columna 2
                        .AlignCenter() // Para alinear al centro
                        .Text("Codigo estudiante SAC").Bold().FontSize(14); // .Bold() -> Estilo de letra .FontSize -> Tamaño de la letra
                    
                    col
                        .Item()
                        .AlignCenter()
                        .Text("Jr. Las mercedes N378-Lima").FontSize(9);
                    col
                        .Item()
                        .AlignCenter()
                        .Text("987 987 123 /02 213232").FontSize(9);
                    col
                        .Item()
                        .AlignCenter()
                        .Text("codigo@example.com").FontSize(9);
                });

            // Fila 3 del header
            row
                .RelativeItem()
                .Column(col =>
                {
                    col
                        .Item() // Agreagamos un item o fila dentro de la columna 2
                        .Border (1) // Activamos para que se vea un borde de 1
                        .BorderColor("#257272") // Ponemos un color al borde
                        .AlignCenter() // Para alinear al centro
                        .Text("RUC 2215154").Bold().FontSize(14); // .Bold() -> Estilo de letra (negrilla) .FontSize -> Tamaño de la letra

                    col
                        .Item()
                        .Border(1) // Activamos para que se vea un borde de 1
                        .BorderColor("#257272") // Ponemos un color al borde
                        .Background("#257272") // Ponemos un fondo al item
                        .AlignCenter() // Alineamos al centro
                        .Text("Boleta de venta").FontColor("#fff"); // Poner un color de letra blanco
                    col
                        .Item() // Agreagamos un item o fila dentro de la columna 2
                        .Border(1) // Activamos para que se vea un borde de 1
                        .BorderColor("#257272") // Ponemos un color al borde
                        .AlignCenter() // Para alinear al centro
                        .Text("B0001 - 234").FontSize(14); // .Bold() -> Estilo de letra .FontSize -> Tamaño de la letra
                });


        }); // ShowOnce() -> Para que solo se muestre en la primera hoja

        // Contenido de la página || .PaddingVertical(10) -> Para separar un poco el contenido del header
        page.Content().PaddingVertical(10).Column(col1 => 
        {
            // Para crear un espacio entre cada col1
            col1.Spacing(10);

            col1
                .Item()
                .Text("Datos del cliente").Bold().Underline(); // Underline() -> Para subrayado


            col1.Item().Column(col2 =>
            {

                col2
                    .Item()
                    .Text(txt =>
                    {
                        txt.Span("Nombre: ").SemiBold().FontSize(10); // span -> Agrega al item de texto hacia la derecha del item
                        txt.Span("Mario Mendoza").FontSize(10); // span -> Agrega al item de texto hacia la derecha del item

                    });


                col2
                    .Item()
                    .Text(txt =>
                    {
                        txt.Span("DNI: ").SemiBold().FontSize(10); // span -> Agrega al item de texto hacia la derecha del item
                        txt.Span("978978978").FontSize(10); // span -> Agrega al item de texto hacia la derecha del item

                    });

                col2
                    .Item()
                    .Text(txt =>
                    {
                        txt.Span("Dirección: ").SemiBold().FontSize(10); // span -> Agrega al item de texto hacia la derecha del item
                        txt.Span("av. miraflores 123").FontSize(10); // span -> Agrega al item de texto hacia la derecha del item

                    });
            });

            

            col1
                .Item()
                .LineHorizontal(0.5f); // Para poner una linea horizontal de 0.5 f-> flotante

            col1
                .Item()
                .Table(tabla => // Para crear una tabla
                {
                    // Defino el número de columnas que tendrá la tabla
                    tabla.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    // Defino los encabezados de la tabla
                    tabla.Header(header =>
                    {
                        // Header 1
                        header
                            .Cell()
                            .Background("#257272")
                            .Padding(2)
                            .Text("Producto")
                            .FontColor("#ffff");

                        // Header 2
                        header
                            .Cell()
                            .Background("#257272")
                            .Padding(2)
                            .Text("Precio Unit")
                            .FontColor("#ffff");

                        // Header 3
                        header
                            .Cell()
                            .Background("#257272")
                            .Padding(2)
                            .Text("Cantidad")
                            .FontColor("#ffff");

                        // Header 4
                        header
                            .Cell()
                            .Background("#257272")
                            .Padding(2)
                            .Text("Total")
                            .FontColor("#ffff");
                    });

                    // Base de datos que se va a repetir 45 veces
                    foreach(var item in Enumerable.Range(1,45))
                    {
                        var cantidad = Placeholders.Random.Next(1, 10);
                        var precio = Placeholders.Random.Next(5000, 10000);
                        var total = cantidad * precio;

                        // Cada vez que tenga un grupo de 4 va a poner una nueva fila y así durante 45 rpeticiones

                        tabla
                            .Cell()
                            .BorderBottom(0.5f)
                            .BorderColor("#D9D9D9")
                            .Padding(2)
                            .Text(Placeholders.Label()).FontSize(10);
                        
                        tabla
                            .Cell()
                            .BorderBottom(0.5f)
                            .BorderColor("#D9D9D9")
                            .Padding(2)
                            .Text($"$ {precio}").FontSize(10);
                        tabla
                            .Cell()
                            .BorderBottom(0.5f)
                            .BorderColor("#D9D9D9")
                            .Padding(2)
                            .Text(cantidad.ToString()).FontSize(10); // .Text($"${total}") -> $ Para que se imprima una variable dentro
                        tabla
                            .Cell()
                            .BorderBottom(0.5f)
                            .BorderColor("#D9D9D9")
                            .Padding(2)
                            .AlignRight()
                            .Text($"$ {total}").FontSize(10); // .Text($"${total}") -> $ Para que se imprima una variable dentro
                    }
                });

            col1
                .Item()
                .AlignRight()
                .Text("Total: 1500").FontSize(12);

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
                        .Text("Comentarios")
                        .FontSize(14);

                    column
                        .Item()
                        .Text(Placeholders.LoremIpsum());

                });
        });

        // Footer de la página
        page.Footer().AlignRight().Text(text =>
        {
            text.Span("Pagina").FontSize(10);
            text.CurrentPageNumber().FontSize(10); // Para poner la página en la que va
            text.Span(" de ").FontSize(10);
            text.TotalPages().FontSize(10);
        });

    });
}).ShowInPreviewer();