Imports System.IO

Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)

        ' The following code is based off, and very similar to,
        ' the following code except for changing some variables
        ' and translating it to VB.Net from C#:
        ' https://jasonkemp.ca/blog/how-to-save-xaml-as-an-image/

        Dim iconrect As Rect = New Rect(IconCanvas.RenderSize)

        Dim rendertargerbitmap As RenderTargetBitmap = New RenderTargetBitmap(IconCanvas.Width, IconCanvas.Height, 96D, 96D, System.Windows.Media.PixelFormats.Default)
        rendertargerbitmap.Render(IconCanvas)
        startcolor.Text = IconCanvas.Height.ToString
        endcolor.Text = IconCanvas.Width.ToString

        Dim pngencoder As BitmapEncoder = New PngBitmapEncoder
        pngencoder.Frames.Add(BitmapFrame.Create(rendertargerbitmap))

        Dim memstream As MemoryStream = New MemoryStream

        pngencoder.Save(memstream)

        memstream.Close()

        File.WriteAllBytes("icon.png", memstream.ToArray())

    End Sub
End Class
