namespace TripPlanner;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
    }

    public async void GoBack(object sender, EventArgs e)
    { 
        await Shell.Current.GoToAsync("MainPage");
    }


    class Drawable : IDrawable
	{
		public void Draw(ICanvas canvas, RectF dirtyRect)
		{

            // View:     frameView
            // NodeName: Strona Lista uczestnik�w widok uczestnika
            // NodeType: FRAME
            // NodeId:   1:14
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(235, 235, 235);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(2.842171E-14f, 0f, 393f, 852f, 0f);
            canvas.RestoreState();


            // View:     rectangleView
            // NodeName: Rectangle 98
            // NodeType: RECTANGLE
            // NodeId:   1:15
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(7f, 127f, 379f, 49f, 25f);
            canvas.RestoreState();


            // View:     rectangleView1
            // NodeName: Rectangle 133
            // NodeType: RECTANGLE
            // NodeId:   1:16
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(7f, 184f, 112f, 22f, 25f);
            canvas.RestoreState();


            // View:     rectangleView2
            // NodeName: Rectangle 134
            // NodeType: RECTANGLE
            // NodeId:   1:17
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(136f, 184f, 112f, 22f, 25f);
            canvas.RestoreState();


            // View:     rectangleView3
            // NodeName: Rectangle 135
            // NodeType: RECTANGLE
            // NodeId:   1:18
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(265f, 183f, 121f, 22f, 25f);
            canvas.RestoreState();


            // View:     rectangleView4
            // NodeName: Rectangle 129
            // NodeType: RECTANGLE
            // NodeId:   1:19
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(7f, 229f, 379f, 616f, 10f);
            canvas.RestoreState();


            // View:     textView
            // NodeName: Eksportuj list� do PDF
            // NodeType: TEXT
            // NodeId:   1:20
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 14f;
            canvas.DrawString(@"Eksportuj list� do PDF", 195f, 812f, 150f, 17f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     frameView1
            // NodeName: download 1
            // NodeType: FRAME
            // NodeId:   1:21
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:22
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(353f, 825.90625f);
            var vector0Builder = new PathBuilder();
            var vector0path = vector0Builder.BuildPath("M0.75 0C0.948912 0 1.13968 0.0823109 1.28033 0.228824C1.42098 0.375337 1.5 0.57405 1.5 0.78125L1.5 4.6875C1.5 5.1019 1.65804 5.49933 1.93934 5.79236C2.22064 6.08538 2.60218 6.25 3 6.25L21 6.25C21.3978 6.25 21.7794 6.08538 22.0607 5.79236C22.342 5.49933 22.5 5.1019 22.5 4.6875L22.5 0.78125C22.5 0.57405 22.579 0.375337 22.7197 0.228824C22.8603 0.0823109 23.0511 0 23.25 0C23.4489 0 23.6397 0.0823109 23.7803 0.228824C23.921 0.375337 24 0.57405 24 0.78125L24 4.6875C24 5.5163 23.6839 6.31116 23.1213 6.89721C22.5587 7.48326 21.7956 7.8125 21 7.8125L3 7.8125C2.20435 7.8125 1.44129 7.48326 0.87868 6.89721C0.316071 6.31116 4.3715e-16 5.5163 0 4.6875L0 0.78125C3.64292e-17 0.57405 0.0790176 0.375337 0.21967 0.228824C0.360322 0.0823109 0.551088 0 0.75 0Z");
            canvas.FillPath(vector0path);
            canvas.RestoreState();


            // View:     imageView1
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:23
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(359.74902f, 812f);
            var vector1Builder = new PathBuilder();
            var vector1path = vector1Builder.BuildPath("M4.71995 16.9594C4.78962 17.0321 4.87238 17.0899 4.9635 17.1292C5.05462 17.1686 5.1523 17.1889 5.25095 17.1889C5.3496 17.1889 5.44728 17.1686 5.5384 17.1292C5.62952 17.0899 5.71228 17.0321 5.78195 16.9594L10.2819 12.2719C10.4228 12.1252 10.5019 11.9262 10.5019 11.7188C10.5019 11.5113 10.4228 11.3123 10.2819 11.1656C10.1411 11.0189 9.95011 10.9365 9.75095 10.9365C9.55178 10.9365 9.36078 11.0189 9.21995 11.1656L6.00095 14.5203L6.00095 0.78125C6.00095 0.57405 5.92193 0.375336 5.78128 0.228823C5.64063 0.08231 5.44986 5.20417e-16 5.25095 0C5.05204 5.20417e-16 4.86127 0.08231 4.72062 0.228823C4.57997 0.375336 4.50095 0.57405 4.50095 0.78125L4.50095 14.5203L1.28195 11.1656C1.14112 11.0189 0.950111 10.9365 0.750948 10.9365C0.551784 10.9365 0.360778 11.0189 0.219948 11.1656C0.0791176 11.3123 0 11.5113 0 11.7188C0 11.9262 0.0791176 12.1252 0.219948 12.2719L4.71995 16.9594Z");
            canvas.FillPath(vector1path);
            canvas.RestoreState();


            // View:     frameView2
            // NodeName: Component 8
            // NodeType: INSTANCE
            // NodeId:   1:24
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView2
            // NodeName: Intersect
            // NodeType: VECTOR
            // NodeId:   I1:24;12:75
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Translate(303.23398f, 19f);
            var vector2Builder = new PathBuilder();
            var vector2path = vector2Builder.BuildPath("M21.8942 4.10798C19.1025 1.57089 15.2342 0 10.9596 0C6.67205 0 2.79352 1.58035 0 4.1309L2.42147 6.31657C4.59525 4.32533 7.61785 3.0909 10.9596 3.0909C14.2886 3.0909 17.3006 4.31585 19.4725 6.2936L21.8942 4.10798Z");
            canvas.FillPath(vector2path);
            canvas.Translate(303.23398f, 19f);
            var vector3Builder = new PathBuilder();
            var vector3path = vector3Builder.BuildPath("M17.9592 7.65959C16.1746 6.03142 13.6975 5.02271 10.9596 5.02271C8.20874 5.02271 5.72144 6.04092 3.93496 7.68258L6.35664 9.86835C7.52317 8.78597 9.15455 8.11361 10.9596 8.11361C12.7519 8.11361 14.3727 8.7764 15.5375 9.84526L17.9592 7.65959Z");
            canvas.FillPath(vector3path);
            canvas.Translate(303.23398f, 19f);
            var vector4Builder = new PathBuilder();
            var vector4path = vector4Builder.BuildPath("M14.024 11.2113C13.2467 10.492 12.1608 10.0454 10.9596 10.0454C9.74544 10.0454 8.64935 10.5017 7.87034 11.2345L10.9343 14L14.024 11.2113Z");
            canvas.FillPath(vector4path);
            canvas.RestoreState();


            // View:     frameView3
            // NodeName: cell
            // NodeType: FRAME
            // NodeId:   I1:24;12:70
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView5
            // NodeName: Rectangle 81
            // NodeType: RECTANGLE
            // NodeId:   I1:24;12:71
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(271.35098f, 28f, 4f, 5f, 1f);
            canvas.RestoreState();


            // View:     rectangleView6
            // NodeName: Rectangle 82
            // NodeType: RECTANGLE
            // NodeId:   I1:24;12:72
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(277.35098f, 25f, 4f, 8f, 1f);
            canvas.RestoreState();


            // View:     rectangleView7
            // NodeName: Rectangle 83
            // NodeType: RECTANGLE
            // NodeId:   I1:24;12:73
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(283.35098f, 22f, 4f, 11f, 1f);
            canvas.RestoreState();


            // View:     rectangleView8
            // NodeName: Rectangle 84
            // NodeType: RECTANGLE
            // NodeId:   I1:24;12:74
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(289.35098f, 19f, 4f, 14f, 1f);
            canvas.RestoreState();


            // View:     frameView4
            // NodeName: Frame 26
            // NodeType: FRAME
            // NodeId:   I1:24;12:76
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView9
            // NodeName: Rectangle 87
            // NodeType: RECTANGLE
            // NodeId:   I1:24;12:77
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.StrokeSize = 3;
            canvas.DrawRoundedRectangle(336.0752f, 21f, 23f, 10f, 2f);
            canvas.RestoreState();


            // View:     rectangleView10
            // NodeName: Rectangle 88
            // NodeType: RECTANGLE
            // NodeId:   I1:24;12:78
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(338.0752f, 22f, 19f, 8f, 4f);
            canvas.RestoreState();


            // View:     rectangleView11
            // NodeName: Rectangle 89
            // NodeType: RECTANGLE
            // NodeId:   I1:24;12:79
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(362.0752f, 22f, 4f, 8f, 0f, 9f, 9f, 0f);
            canvas.RestoreState();


            // View:     textView1
            // NodeName: 11:42
            // NodeType: TEXT
            // NodeId:   I1:24;12:84
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter", 400, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"11:42", 2.842171E-14f, 17f, 60.20891f, 17f, HorizontalAlignment.Left, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     rectangleView12
            // NodeName: Rectangle 90
            // NodeType: RECTANGLE
            // NodeId:   1:25
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(2.842171E-14f, 0f, 393f, 120f, 0f);
            canvas.RestoreState();


            // View:     textView2
            // NodeName: Uczestnicy wyjazdu - Narty 2023
            // NodeType: TEXT
            // NodeId:   1:26
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter", 400, FontStyleType.Normal);
            canvas.FontSize = 18f;
            canvas.DrawString(@"Uczestnicy wyjazdu - Narty 2023", 81f, 76f, 285f, 22f, HorizontalAlignment.Left, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView3
            // NodeName: Gotowe
            // NodeType: TEXT
            // NodeId:   1:27
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-SemiBold", 600, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Gotowe", 159f, 751f, 75f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     frameView5
            // NodeName: Component 9
            // NodeType: INSTANCE
            // NodeId:   1:28
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView3
            // NodeName: Intersect
            // NodeType: VECTOR
            // NodeId:   I1:28;12:75
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Translate(303.23398f, 19f);
            var vector5Builder = new PathBuilder();
            var vector5path = vector5Builder.BuildPath("M21.8942 4.10798C19.1025 1.57089 15.2342 0 10.9596 0C6.67205 0 2.79352 1.58035 0 4.1309L2.42147 6.31657C4.59525 4.32533 7.61785 3.0909 10.9596 3.0909C14.2886 3.0909 17.3006 4.31585 19.4725 6.2936L21.8942 4.10798Z");
            canvas.FillPath(vector5path);
            canvas.Translate(303.23398f, 19f);
            var vector6Builder = new PathBuilder();
            var vector6path = vector6Builder.BuildPath("M17.9592 7.65959C16.1746 6.03142 13.6975 5.02271 10.9596 5.02271C8.20874 5.02271 5.72144 6.04092 3.93496 7.68258L6.35664 9.86835C7.52317 8.78597 9.15455 8.11361 10.9596 8.11361C12.7519 8.11361 14.3727 8.7764 15.5375 9.84526L17.9592 7.65959Z");
            canvas.FillPath(vector6path);
            canvas.Translate(303.23398f, 19f);
            var vector7Builder = new PathBuilder();
            var vector7path = vector7Builder.BuildPath("M14.024 11.2113C13.2467 10.492 12.1608 10.0454 10.9596 10.0454C9.74544 10.0454 8.64935 10.5017 7.87034 11.2345L10.9343 14L14.024 11.2113Z");
            canvas.FillPath(vector7path);
            canvas.RestoreState();


            // View:     frameView6
            // NodeName: cell
            // NodeType: FRAME
            // NodeId:   I1:28;12:70
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView13
            // NodeName: Rectangle 81
            // NodeType: RECTANGLE
            // NodeId:   I1:28;12:71
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(271.35098f, 28f, 4f, 5f, 1f);
            canvas.RestoreState();


            // View:     rectangleView14
            // NodeName: Rectangle 82
            // NodeType: RECTANGLE
            // NodeId:   I1:28;12:72
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(277.35098f, 25f, 4f, 8f, 1f);
            canvas.RestoreState();


            // View:     rectangleView15
            // NodeName: Rectangle 83
            // NodeType: RECTANGLE
            // NodeId:   I1:28;12:73
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(283.35098f, 22f, 4f, 11f, 1f);
            canvas.RestoreState();


            // View:     rectangleView16
            // NodeName: Rectangle 84
            // NodeType: RECTANGLE
            // NodeId:   I1:28;12:74
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(289.35098f, 19f, 4f, 14f, 1f);
            canvas.RestoreState();


            // View:     frameView7
            // NodeName: Frame 26
            // NodeType: FRAME
            // NodeId:   I1:28;12:76
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView17
            // NodeName: Rectangle 87
            // NodeType: RECTANGLE
            // NodeId:   I1:28;12:77
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.StrokeSize = 3;
            canvas.DrawRoundedRectangle(336.0752f, 21f, 23f, 10f, 2f);
            canvas.RestoreState();


            // View:     rectangleView18
            // NodeName: Rectangle 88
            // NodeType: RECTANGLE
            // NodeId:   I1:28;12:78
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(338.0752f, 22f, 19f, 8f, 4f);
            canvas.RestoreState();


            // View:     rectangleView19
            // NodeName: Rectangle 89
            // NodeType: RECTANGLE
            // NodeId:   I1:28;12:79
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(362.0752f, 22f, 4f, 8f, 0f, 9f, 9f, 0f);
            canvas.RestoreState();


            // View:     textView4
            // NodeName: 11:42
            // NodeType: TEXT
            // NodeId:   I1:28;12:84
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter", 400, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"11:42", 2.842171E-14f, 17f, 60.20891f, 17f, HorizontalAlignment.Left, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     frameView8
            // NodeName: Ic_arrow_back_36px 4
            // NodeType: FRAME
            // NodeId:   1:29
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView4
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:30

            // View:     imageView5
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:31
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(122, 122, 122);
            canvas.Alpha = 1;
            canvas.Translate(25f, 74f);
            var vector8Builder = new PathBuilder();
            var vector8path = vector8Builder.BuildPath("M24 10.5L5.74 10.5L14.12 2.12L12 0L0 12L12 24L14.12 21.88L5.74 13.5L24 13.5L24 10.5Z");
            canvas.FillPath(vector8path);
            canvas.RestoreState();


            // View:     elipseView
            // NodeName: Ellipse 8
            // NodeType: ELLIPSE
            // NodeId:   1:32
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillEllipse(13f, 63f, 47f, 47f);
            canvas.StrokeColor = Color.FromRgb(122, 122, 122);
            canvas.Alpha = 1;
            canvas.StrokeSize = 1;
            canvas.DrawEllipse(13f, 63f, 47f, 47f);
            canvas.RestoreState();


            // View:     textView5
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:33
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 240f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView6
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:34
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 275f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView
            // NodeName: Line 1
            // NodeType: LINE
            // NodeId:   1:35
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 306), new Point(385.99997, 307));
            canvas.RestoreState();


            // View:     frameView9
            // NodeName: bank 1
            // NodeType: FRAME
            // NodeId:   1:36
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView6
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:37
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(210f, 240f);
            var vector9Builder = new PathBuilder();
            var vector9path = vector9Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector9path);
            canvas.RestoreState();


            // View:     frameView10
            // NodeName: award (1) 1
            // NodeType: FRAME
            // NodeId:   1:38
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView7
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:39
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 241f);
            var vector10Builder = new PathBuilder();
            var vector10path = vector10Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector10path);
            canvas.RestoreState();


            // View:     imageView8
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:40
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(258f, 258.691f);
            var vector11Builder = new PathBuilder();
            var vector11path = vector11Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector11path);
            canvas.RestoreState();


            // View:     imageView9
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:41
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 317f);
            var vector12Builder = new PathBuilder();
            var vector12path = vector12Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector12path);
            canvas.RestoreState();


            // View:     frameView11
            // NodeName: award (1) 3
            // NodeType: FRAME
            // NodeId:   1:42
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView10
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:43
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 318f);
            var vector13Builder = new PathBuilder();
            var vector13path = vector13Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector13path);
            canvas.RestoreState();


            // View:     imageView11
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:44
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 335.691f);
            var vector14Builder = new PathBuilder();
            var vector14path = vector14Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector14path);
            canvas.RestoreState();


            // View:     imageView12
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:45
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 475f);
            var vector15Builder = new PathBuilder();
            var vector15path = vector15Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector15path);
            canvas.RestoreState();


            // View:     frameView12
            // NodeName: award (1) 4
            // NodeType: FRAME
            // NodeId:   1:46
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView13
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:47
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 476f);
            var vector16Builder = new PathBuilder();
            var vector16path = vector16Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector16path);
            canvas.RestoreState();


            // View:     imageView14
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:48
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 493.691f);
            var vector17Builder = new PathBuilder();
            var vector17path = vector17Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector17path);
            canvas.RestoreState();


            // View:     imageView15
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:49
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 554f);
            var vector18Builder = new PathBuilder();
            var vector18path = vector18Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector18path);
            canvas.RestoreState();


            // View:     frameView13
            // NodeName: award (1) 5
            // NodeType: FRAME
            // NodeId:   1:50
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView16
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:51
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 555f);
            var vector19Builder = new PathBuilder();
            var vector19path = vector19Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector19path);
            canvas.RestoreState();


            // View:     imageView17
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:52
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 572.691f);
            var vector20Builder = new PathBuilder();
            var vector20path = vector20Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector20path);
            canvas.RestoreState();


            // View:     imageView18
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:53
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 396f);
            var vector21Builder = new PathBuilder();
            var vector21path = vector21Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector21path);
            canvas.RestoreState();


            // View:     frameView14
            // NodeName: award (1) 2
            // NodeType: FRAME
            // NodeId:   1:54
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView19
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:55
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 397f);
            var vector22Builder = new PathBuilder();
            var vector22path = vector22Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector22path);
            canvas.RestoreState();


            // View:     imageView20
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:56
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 414.691f);
            var vector23Builder = new PathBuilder();
            var vector23path = vector23Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector23path);
            canvas.RestoreState();


            // View:     textView7
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:57
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 318f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView8
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:58
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 353f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView1
            // NodeName: Line 2
            // NodeType: LINE
            // NodeId:   1:59
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 384), new Point(385.99997, 385));
            canvas.RestoreState();


            // View:     textView9
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:60
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 397f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView10
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:61
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 432f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView2
            // NodeName: Line 3
            // NodeType: LINE
            // NodeId:   1:62
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 463), new Point(385.99997, 464));
            canvas.RestoreState();


            // View:     textView11
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:63
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 476f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView12
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:64
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 511f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView3
            // NodeName: Line 4
            // NodeType: LINE
            // NodeId:   1:65
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 542), new Point(385.99997, 543));
            canvas.RestoreState();


            // View:     textView13
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:66
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 555f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView14
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:67
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 590f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView4
            // NodeName: Line 5
            // NodeType: LINE
            // NodeId:   1:68
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 621), new Point(385.99997, 622));
            canvas.RestoreState();


            // View:     frameView15
            // NodeName: plus-circle 2
            // NodeType: FRAME
            // NodeId:   1:69
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView21
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:70
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(184f, 641f);
            var vector24Builder = new PathBuilder();
            var vector24path = vector24Builder.BuildPath("M26.5 49.6875C20.3503 49.6875 14.4525 47.2445 10.104 42.896C5.75546 38.5475 3.3125 32.6497 3.3125 26.5C3.3125 20.3503 5.75546 14.4525 10.104 10.104C14.4525 5.75546 20.3503 3.3125 26.5 3.3125C32.6497 3.3125 38.5475 5.75546 42.896 10.104C47.2445 14.4525 49.6875 20.3503 49.6875 26.5C49.6875 32.6497 47.2445 38.5475 42.896 42.896C38.5475 47.2445 32.6497 49.6875 26.5 49.6875ZM26.5 53C33.5282 53 40.2686 50.208 45.2383 45.2383C50.208 40.2686 53 33.5282 53 26.5C53 19.4718 50.208 12.7314 45.2383 7.76167C40.2686 2.79196 33.5282 4.41314e-15 26.5 0C19.4718 5.14866e-15 12.7314 2.79196 7.76167 7.76167C2.79196 12.7314 7.17135e-15 19.4718 0 26.5C5.51642e-15 33.5282 2.79196 40.2686 7.76167 45.2383C12.7314 50.208 19.4718 53 26.5 53Z");
            canvas.FillPath(vector24path);
            canvas.RestoreState();


            // View:     imageView22
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:71
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(197.25f, 654.25f);
            var vector25Builder = new PathBuilder();
            var vector25path = vector25Builder.BuildPath("M13.25 0C13.6893 -1.47105e-15 14.1105 0.174498 14.4211 0.485105C14.7318 0.795712 14.9062 1.21699 14.9062 1.65625L14.9062 11.5938L24.8438 11.5938C25.283 11.5938 25.7043 11.7682 26.0149 12.0789C26.3255 12.3895 26.5 12.8107 26.5 13.25C26.5 13.6893 26.3255 14.1105 26.0149 14.4211C25.7043 14.7318 25.283 14.9062 24.8438 14.9062L14.9062 14.9062L14.9062 24.8438C14.9062 25.283 14.7318 25.7043 14.4211 26.0149C14.1105 26.3255 13.6893 26.5 13.25 26.5C12.8107 26.5 12.3895 26.3255 12.0789 26.0149C11.7682 25.7043 11.5938 25.283 11.5938 24.8438L11.5938 14.9062L1.65625 14.9062C1.21699 14.9062 0.795712 14.7318 0.485105 14.4211C0.174498 14.1105 -1.47105e-15 13.6893 0 13.25C-1.47105e-15 12.8107 0.174498 12.3895 0.485105 12.0789C0.795712 11.7682 1.21699 11.5938 1.65625 11.5938L11.5938 11.5938L11.5938 1.65625C11.5938 1.21699 11.7682 0.795712 12.0789 0.485105C12.3895 0.174498 12.8107 -1.47105e-15 13.25 0Z");
            canvas.FillPath(vector25path);
            canvas.RestoreState();


            // View:     rectangleView20
            // NodeName: Rectangle 131
            // NodeType: RECTANGLE
            // NodeId:   1:72
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(7f, 229f, 379f, 616f, 10f);
            canvas.RestoreState();


            // View:     textView15
            // NodeName: Eksportuj list� do PDF
            // NodeType: TEXT
            // NodeId:   1:73
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 14f;
            canvas.DrawString(@"Eksportuj list� do PDF", 195f, 812f, 150f, 17f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     frameView16
            // NodeName: download 2
            // NodeType: FRAME
            // NodeId:   1:74
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView23
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:75
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(353f, 825.90625f);
            var vector26Builder = new PathBuilder();
            var vector26path = vector26Builder.BuildPath("M0.75 0C0.948912 0 1.13968 0.0823109 1.28033 0.228824C1.42098 0.375337 1.5 0.57405 1.5 0.78125L1.5 4.6875C1.5 5.1019 1.65804 5.49933 1.93934 5.79236C2.22064 6.08538 2.60218 6.25 3 6.25L21 6.25C21.3978 6.25 21.7794 6.08538 22.0607 5.79236C22.342 5.49933 22.5 5.1019 22.5 4.6875L22.5 0.78125C22.5 0.57405 22.579 0.375337 22.7197 0.228824C22.8603 0.0823109 23.0511 0 23.25 0C23.4489 0 23.6397 0.0823109 23.7803 0.228824C23.921 0.375337 24 0.57405 24 0.78125L24 4.6875C24 5.5163 23.6839 6.31116 23.1213 6.89721C22.5587 7.48326 21.7956 7.8125 21 7.8125L3 7.8125C2.20435 7.8125 1.44129 7.48326 0.87868 6.89721C0.316071 6.31116 4.3715e-16 5.5163 0 4.6875L0 0.78125C3.64292e-17 0.57405 0.0790176 0.375337 0.21967 0.228824C0.360322 0.0823109 0.551088 0 0.75 0Z");
            canvas.FillPath(vector26path);
            canvas.RestoreState();


            // View:     imageView24
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:76
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(359.74902f, 812f);
            var vector27Builder = new PathBuilder();
            var vector27path = vector27Builder.BuildPath("M4.71995 16.9594C4.78962 17.0321 4.87238 17.0899 4.9635 17.1292C5.05462 17.1686 5.1523 17.1889 5.25095 17.1889C5.3496 17.1889 5.44728 17.1686 5.5384 17.1292C5.62952 17.0899 5.71228 17.0321 5.78195 16.9594L10.2819 12.2719C10.4228 12.1252 10.5019 11.9262 10.5019 11.7188C10.5019 11.5113 10.4228 11.3123 10.2819 11.1656C10.1411 11.0189 9.95011 10.9365 9.75095 10.9365C9.55178 10.9365 9.36078 11.0189 9.21995 11.1656L6.00095 14.5203L6.00095 0.78125C6.00095 0.57405 5.92193 0.375336 5.78128 0.228823C5.64063 0.08231 5.44986 5.20417e-16 5.25095 0C5.05204 5.20417e-16 4.86127 0.08231 4.72062 0.228823C4.57997 0.375336 4.50095 0.57405 4.50095 0.78125L4.50095 14.5203L1.28195 11.1656C1.14112 11.0189 0.950111 10.9365 0.750948 10.9365C0.551784 10.9365 0.360778 11.0189 0.219948 11.1656C0.0791176 11.3123 0 11.5113 0 11.7188C0 11.9262 0.0791176 12.1252 0.219948 12.2719L4.71995 16.9594Z");
            canvas.FillPath(vector27path);
            canvas.RestoreState();


            // View:     frameView17
            // NodeName: Component 10
            // NodeType: INSTANCE
            // NodeId:   1:77
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView25
            // NodeName: Intersect
            // NodeType: VECTOR
            // NodeId:   I1:77;12:75
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Translate(303.23398f, 19f);
            var vector28Builder = new PathBuilder();
            var vector28path = vector28Builder.BuildPath("M21.8942 4.10798C19.1025 1.57089 15.2342 0 10.9596 0C6.67205 0 2.79352 1.58035 0 4.1309L2.42147 6.31657C4.59525 4.32533 7.61785 3.0909 10.9596 3.0909C14.2886 3.0909 17.3006 4.31585 19.4725 6.2936L21.8942 4.10798Z");
            canvas.FillPath(vector28path);
            canvas.Translate(303.23398f, 19f);
            var vector29Builder = new PathBuilder();
            var vector29path = vector29Builder.BuildPath("M17.9592 7.65959C16.1746 6.03142 13.6975 5.02271 10.9596 5.02271C8.20874 5.02271 5.72144 6.04092 3.93496 7.68258L6.35664 9.86835C7.52317 8.78597 9.15455 8.11361 10.9596 8.11361C12.7519 8.11361 14.3727 8.7764 15.5375 9.84526L17.9592 7.65959Z");
            canvas.FillPath(vector29path);
            canvas.Translate(303.23398f, 19f);
            var vector30Builder = new PathBuilder();
            var vector30path = vector30Builder.BuildPath("M14.024 11.2113C13.2467 10.492 12.1608 10.0454 10.9596 10.0454C9.74544 10.0454 8.64935 10.5017 7.87034 11.2345L10.9343 14L14.024 11.2113Z");
            canvas.FillPath(vector30path);
            canvas.RestoreState();


            // View:     frameView18
            // NodeName: cell
            // NodeType: FRAME
            // NodeId:   I1:77;12:70
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView21
            // NodeName: Rectangle 81
            // NodeType: RECTANGLE
            // NodeId:   I1:77;12:71
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(271.35098f, 28f, 4f, 5f, 1f);
            canvas.RestoreState();


            // View:     rectangleView22
            // NodeName: Rectangle 82
            // NodeType: RECTANGLE
            // NodeId:   I1:77;12:72
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(277.35098f, 25f, 4f, 8f, 1f);
            canvas.RestoreState();


            // View:     rectangleView23
            // NodeName: Rectangle 83
            // NodeType: RECTANGLE
            // NodeId:   I1:77;12:73
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(283.35098f, 22f, 4f, 11f, 1f);
            canvas.RestoreState();


            // View:     rectangleView24
            // NodeName: Rectangle 84
            // NodeType: RECTANGLE
            // NodeId:   I1:77;12:74
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(289.35098f, 19f, 4f, 14f, 1f);
            canvas.RestoreState();


            // View:     frameView19
            // NodeName: Frame 26
            // NodeType: FRAME
            // NodeId:   I1:77;12:76
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView25
            // NodeName: Rectangle 87
            // NodeType: RECTANGLE
            // NodeId:   I1:77;12:77
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.StrokeSize = 3;
            canvas.DrawRoundedRectangle(336.0752f, 21f, 23f, 10f, 2f);
            canvas.RestoreState();


            // View:     rectangleView26
            // NodeName: Rectangle 88
            // NodeType: RECTANGLE
            // NodeId:   I1:77;12:78
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(338.0752f, 22f, 19f, 8f, 4f);
            canvas.RestoreState();


            // View:     rectangleView27
            // NodeName: Rectangle 89
            // NodeType: RECTANGLE
            // NodeId:   I1:77;12:79
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(362.0752f, 22f, 4f, 8f, 0f, 9f, 9f, 0f);
            canvas.RestoreState();


            // View:     textView16
            // NodeName: 11:42
            // NodeType: TEXT
            // NodeId:   I1:77;12:84
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter", 400, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"11:42", 2.842171E-14f, 17f, 60.20891f, 17f, HorizontalAlignment.Left, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     rectangleView28
            // NodeName: Rectangle 132
            // NodeType: RECTANGLE
            // NodeId:   1:78
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(2.842171E-14f, 0f, 393f, 120f, 0f);
            canvas.RestoreState();


            // View:     textView17
            // NodeName: Uczestnicy wyjazdu - Narty 2023
            // NodeType: TEXT
            // NodeId:   1:79
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter", 400, FontStyleType.Normal);
            canvas.FontSize = 18f;
            canvas.DrawString(@"Uczestnicy wyjazdu - Narty 2023", 81f, 76f, 285f, 22f, HorizontalAlignment.Left, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView18
            // NodeName: Gotowe
            // NodeType: TEXT
            // NodeId:   1:80
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-SemiBold", 600, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Gotowe", 159f, 751f, 75f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     frameView20
            // NodeName: Component 11
            // NodeType: INSTANCE
            // NodeId:   1:81
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView26
            // NodeName: Intersect
            // NodeType: VECTOR
            // NodeId:   I1:81;12:75
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Translate(303.23398f, 18f);
            var vector31Builder = new PathBuilder();
            var vector31path = vector31Builder.BuildPath("M21.8942 4.10798C19.1025 1.57089 15.2342 0 10.9596 0C6.67205 0 2.79352 1.58035 0 4.1309L2.42147 6.31657C4.59525 4.32533 7.61785 3.0909 10.9596 3.0909C14.2886 3.0909 17.3006 4.31585 19.4725 6.2936L21.8942 4.10798Z");
            canvas.FillPath(vector31path);
            canvas.Translate(303.23398f, 18f);
            var vector32Builder = new PathBuilder();
            var vector32path = vector32Builder.BuildPath("M17.9592 7.65959C16.1746 6.03142 13.6975 5.02271 10.9596 5.02271C8.20874 5.02271 5.72144 6.04092 3.93496 7.68258L6.35664 9.86835C7.52317 8.78597 9.15455 8.11361 10.9596 8.11361C12.7519 8.11361 14.3727 8.7764 15.5375 9.84526L17.9592 7.65959Z");
            canvas.FillPath(vector32path);
            canvas.Translate(303.23398f, 18f);
            var vector33Builder = new PathBuilder();
            var vector33path = vector33Builder.BuildPath("M14.024 11.2113C13.2467 10.492 12.1608 10.0454 10.9596 10.0454C9.74544 10.0454 8.64935 10.5017 7.87034 11.2345L10.9343 14L14.024 11.2113Z");
            canvas.FillPath(vector33path);
            canvas.RestoreState();


            // View:     frameView21
            // NodeName: cell
            // NodeType: FRAME
            // NodeId:   I1:81;12:70
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView29
            // NodeName: Rectangle 81
            // NodeType: RECTANGLE
            // NodeId:   I1:81;12:71
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(271.35098f, 27f, 4f, 5f, 1f);
            canvas.RestoreState();


            // View:     rectangleView30
            // NodeName: Rectangle 82
            // NodeType: RECTANGLE
            // NodeId:   I1:81;12:72
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(277.35098f, 24f, 4f, 8f, 1f);
            canvas.RestoreState();


            // View:     rectangleView31
            // NodeName: Rectangle 83
            // NodeType: RECTANGLE
            // NodeId:   I1:81;12:73
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(283.35098f, 21f, 4f, 11f, 1f);
            canvas.RestoreState();


            // View:     rectangleView32
            // NodeName: Rectangle 84
            // NodeType: RECTANGLE
            // NodeId:   I1:81;12:74
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(289.35098f, 18f, 4f, 14f, 1f);
            canvas.RestoreState();


            // View:     frameView22
            // NodeName: Frame 26
            // NodeType: FRAME
            // NodeId:   I1:81;12:76
            canvas.SaveState();
            canvas.RestoreState();


            // View:     rectangleView33
            // NodeName: Rectangle 87
            // NodeType: RECTANGLE
            // NodeId:   I1:81;12:77
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.StrokeSize = 3;
            canvas.DrawRoundedRectangle(336.0752f, 20f, 23f, 10f, 2f);
            canvas.RestoreState();


            // View:     rectangleView34
            // NodeName: Rectangle 88
            // NodeType: RECTANGLE
            // NodeId:   I1:81;12:78
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(338.0752f, 21f, 19f, 8f, 4f);
            canvas.RestoreState();


            // View:     rectangleView35
            // NodeName: Rectangle 89
            // NodeType: RECTANGLE
            // NodeId:   I1:81;12:79
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.FillRoundedRectangle(362.0752f, 21f, 4f, 8f, 0f, 9f, 9f, 0f);
            canvas.RestoreState();


            // View:     textView19
            // NodeName: 11:42
            // NodeType: TEXT
            // NodeId:   I1:81;12:84
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter", 400, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"11:42", 2.842171E-14f, 16f, 60.20891f, 17f, HorizontalAlignment.Left, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     frameView23
            // NodeName: Ic_arrow_back_36px 5
            // NodeType: FRAME
            // NodeId:   1:82
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView27
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:83

            // View:     imageView28
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:84
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(122, 122, 122);
            canvas.Alpha = 1;
            canvas.Translate(25f, 74f);
            var vector34Builder = new PathBuilder();
            var vector34path = vector34Builder.BuildPath("M24 10.5L5.74 10.5L14.12 2.12L12 0L0 12L12 24L14.12 21.88L5.74 13.5L24 13.5L24 10.5Z");
            canvas.FillPath(vector34path);
            canvas.RestoreState();


            // View:     elipseView1
            // NodeName: Ellipse 9
            // NodeType: ELLIPSE
            // NodeId:   1:85
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(255, 255, 255);
            canvas.Alpha = 1;
            canvas.FillEllipse(13f, 63f, 47f, 47f);
            canvas.StrokeColor = Color.FromRgb(122, 122, 122);
            canvas.Alpha = 1;
            canvas.StrokeSize = 1;
            canvas.DrawEllipse(13f, 63f, 47f, 47f);
            canvas.RestoreState();


            // View:     frameView24
            // NodeName: search 1
            // NodeType: FRAME
            // NodeId:   1:86
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView29
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:87
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(0, 0, 0);
            canvas.Alpha = 1;
            canvas.Translate(21.998707f, 139.00282f);
            var vector35Builder = new PathBuilder();
            var vector35path = vector35Builder.BuildPath("M17.6143 16.1596C19.0668 14.0951 19.7173 11.5354 19.4358 8.99265C19.1543 6.44993 17.9615 4.1117 16.096 2.44575C14.2305 0.779794 11.83 -0.0910142 9.3746 0.00753763C6.91923 0.106089 4.59012 1.16673 2.85325 2.97727C1.11637 4.78781 0.0998225 7.21472 0.0069698 9.77247C-0.0858829 12.3302 0.751811 14.8302 2.35246 16.7722C3.95311 18.7142 6.19866 19.955 8.63988 20.2465C11.0811 20.5379 13.5379 19.8584 15.5188 18.344L15.5173 18.344C15.5623 18.4065 15.6103 18.4659 15.6643 18.5237L21.4393 24.5393C21.7206 24.8325 22.1022 24.9973 22.5001 24.9974C22.898 24.9976 23.2796 24.8331 23.5611 24.5401C23.8426 24.2471 24.0008 23.8496 24.0009 23.4352C24.001 23.0207 23.8431 22.6231 23.5618 22.3299L17.7868 16.3143C17.7332 16.2577 17.6756 16.2071 17.6143 16.1596ZM18.0013 10.1534C18.0013 11.2819 17.788 12.3994 17.3734 13.442C16.9588 14.4847 16.3511 15.4321 15.585 16.2301C14.8189 17.0281 13.9094 17.6611 12.9085 18.0929C11.9075 18.5248 10.8348 18.7471 9.75135 18.7471C8.66794 18.7471 7.59514 18.5248 6.59421 18.0929C5.59327 17.6611 4.6838 17.0281 3.91772 16.2301C3.15163 15.4321 2.54394 14.4847 2.12934 13.442C1.71474 12.3994 1.50135 11.2819 1.50135 10.1534C1.50135 7.87415 2.37054 5.6883 3.91772 4.07666C5.46489 2.46502 7.56331 1.55961 9.75135 1.55961C11.9394 1.55961 14.0378 2.46502 15.585 4.07666C17.1322 5.6883 18.0013 7.87415 18.0013 10.1534Z");
            canvas.FillPath(vector35path);
            canvas.RestoreState();


            // View:     textView20
            // NodeName: Wyszukaj uczestnika
            // NodeType: TEXT
            // NodeId:   1:88
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(197, 197, 197);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter", 400, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Wyszukaj uczestnika", 55f, 139f, 197f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView21
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:89
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 240f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView22
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:90
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 275f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView5
            // NodeName: Line 6
            // NodeType: LINE
            // NodeId:   1:91
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 306), new Point(385.99997, 307));
            canvas.RestoreState();


            // View:     frameView25
            // NodeName: bank 2
            // NodeType: FRAME
            // NodeId:   1:92
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView30
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:93
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(210f, 240f);
            var vector36Builder = new PathBuilder();
            var vector36path = vector36Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector36path);
            canvas.RestoreState();


            // View:     frameView26
            // NodeName: award (1) 6
            // NodeType: FRAME
            // NodeId:   1:94
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView31
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:95
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 241f);
            var vector37Builder = new PathBuilder();
            var vector37path = vector37Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector37path);
            canvas.RestoreState();


            // View:     imageView32
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:96
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Translate(258f, 258.691f);
            var vector38Builder = new PathBuilder();
            var vector38path = vector38Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector38path);
            canvas.RestoreState();


            // View:     imageView33
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:97
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 317f);
            var vector39Builder = new PathBuilder();
            var vector39path = vector39Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector39path);
            canvas.RestoreState();


            // View:     frameView27
            // NodeName: award (1) 7
            // NodeType: FRAME
            // NodeId:   1:98
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView34
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:99
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 318f);
            var vector40Builder = new PathBuilder();
            var vector40path = vector40Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector40path);
            canvas.RestoreState();


            // View:     imageView35
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:100
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 335.691f);
            var vector41Builder = new PathBuilder();
            var vector41path = vector41Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector41path);
            canvas.RestoreState();


            // View:     imageView36
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:101
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 475f);
            var vector42Builder = new PathBuilder();
            var vector42path = vector42Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector42path);
            canvas.RestoreState();


            // View:     frameView28
            // NodeName: award (1) 8
            // NodeType: FRAME
            // NodeId:   1:102
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView37
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:103
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 476f);
            var vector43Builder = new PathBuilder();
            var vector43path = vector43Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector43path);
            canvas.RestoreState();


            // View:     imageView38
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:104
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 493.691f);
            var vector44Builder = new PathBuilder();
            var vector44path = vector44Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector44path);
            canvas.RestoreState();


            // View:     imageView39
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:105
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 554f);
            var vector45Builder = new PathBuilder();
            var vector45path = vector45Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector45path);
            canvas.RestoreState();


            // View:     frameView29
            // NodeName: award (1) 9
            // NodeType: FRAME
            // NodeId:   1:106
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView40
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:107
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 555f);
            var vector46Builder = new PathBuilder();
            var vector46path = vector46Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector46path);
            canvas.RestoreState();


            // View:     imageView41
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:108
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 572.691f);
            var vector47Builder = new PathBuilder();
            var vector47path = vector47Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector47path);
            canvas.RestoreState();


            // View:     imageView42
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:109
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(210f, 396f);
            var vector48Builder = new PathBuilder();
            var vector48path = vector48Builder.BuildPath("M12.0003 0L21.9153 4.5L23.2503 4.5C23.4492 4.5 23.6399 4.57902 23.7806 4.71967C23.9212 4.86032 24.0003 5.05109 24.0003 5.25L24.0003 8.25C24.0003 8.44891 23.9212 8.63968 23.7806 8.78033C23.6399 8.92098 23.4492 9 23.2503 9L22.5003 9L22.5003 19.5C22.6678 19.5001 22.8304 19.5563 22.9622 19.6596C23.0941 19.7629 23.1876 19.9074 23.2278 20.07L23.9778 23.07C24.0057 23.1805 24.008 23.2959 23.9844 23.4074C23.9609 23.5189 23.9121 23.6235 23.8419 23.7133C23.7717 23.803 23.6819 23.8755 23.5793 23.9252C23.4768 23.9749 23.3642 24.0005 23.2503 24L0.750264 24C0.636311 24.0005 0.523753 23.9749 0.421207 23.9252C0.318661 23.8755 0.228845 23.803 0.158634 23.7133C0.0884218 23.6235 0.0396755 23.5189 0.0161256 23.4074C-0.00742429 23.2959 -0.00515347 23.1805 0.0227643 23.07L0.772764 20.07C0.813201 19.9075 0.906738 19.7632 1.03853 19.6599C1.17033 19.5567 1.33283 19.5004 1.50026 19.5L1.50026 9L0.750264 9C0.551352 9 0.360586 8.92098 0.219934 8.78033C0.0792819 8.63968 0.000264278 8.44891 0.000264278 8.25L0.000264278 5.25C0.000264278 5.05109 0.0792819 4.86032 0.219934 4.71967C0.360586 4.57902 0.551352 4.5 0.750264 4.5L2.08526 4.5L12.0003 0ZM5.66576 4.5L18.3363 4.5L12.0003 1.5L5.66576 4.5ZM3.00026 9L3.00026 19.5L4.50026 19.5L4.50026 9L3.00026 9ZM6.00026 9L6.00026 19.5L9.75026 19.5L9.75026 9L6.00026 9ZM11.2503 9L11.2503 19.5L12.7503 19.5L12.7503 9L11.2503 9ZM14.2503 9L14.2503 19.5L18.0003 19.5L18.0003 9L14.2503 9ZM19.5003 9L19.5003 19.5L21.0003 19.5L21.0003 9L19.5003 9ZM22.5003 7.5L22.5003 6L1.50026 6L1.50026 7.5L22.5003 7.5ZM21.9153 21L2.08526 21L1.71026 22.5L22.2903 22.5L21.9153 21Z");
            canvas.FillPath(vector48path);
            canvas.RestoreState();


            // View:     frameView30
            // NodeName: award (1) 10
            // NodeType: FRAME
            // NodeId:   1:110
            canvas.SaveState();
            canvas.RestoreState();


            // View:     imageView43
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:111
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(255.441f, 397f);
            var vector49Builder = new PathBuilder();
            var vector49path = vector49Builder.BuildPath("M11.0625 1.296L8.559 0L6.0555 1.296L3.2685 1.719L2.0055 4.239L0 6.219L0.459 9L0 11.781L2.0055 13.761L3.2685 16.281L6.0555 16.704L8.559 18L11.0625 16.704L13.8495 16.281L15.1125 13.761L17.118 11.781L16.659 9L17.118 6.219L15.1125 4.239L13.8495 1.719L11.0625 1.296ZM12.8565 3.0855L13.8825 5.133L15.5115 6.741L15.1395 9L15.5115 11.259L13.8825 12.867L12.8565 14.9145L10.5915 15.258L8.559 16.311L6.5265 15.258L4.2615 14.9145L3.2355 12.867L1.6065 11.259L1.98 9L1.605 6.741L3.2355 5.133L4.2615 3.0855L6.5265 2.742L8.559 1.689L10.593 2.742L12.8565 3.0855Z");
            canvas.FillPath(vector49path);
            canvas.RestoreState();


            // View:     imageView44
            // NodeName: Vector
            // NodeType: VECTOR
            // NodeId:   1:112
            canvas.SaveState();
            canvas.FillColor = Color.FromRgb(200, 216, 228);
            canvas.Alpha = 1;
            canvas.Translate(258f, 414.691f);
            var vector50Builder = new PathBuilder();
            var vector50path = vector50Builder.BuildPath("M0 0L0 6.309L6 4.809L12 6.309L12 0L8.973 0.459001L6 1.998L3.027 0.459001L0 0Z");
            canvas.FillPath(vector50path);
            canvas.RestoreState();


            // View:     textView23
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:113
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 318f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView24
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:114
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 353f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView6
            // NodeName: Line 7
            // NodeType: LINE
            // NodeId:   1:115
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 384), new Point(385.99997, 385));
            canvas.RestoreState();


            // View:     textView25
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:116
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 397f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView26
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:117
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 432f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView7
            // NodeName: Line 8
            // NodeType: LINE
            // NodeId:   1:118
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 463), new Point(385.99997, 464));
            canvas.RestoreState();


            // View:     textView27
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:119
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 476f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView28
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:120
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 511f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView8
            // NodeName: Line 9
            // NodeType: LINE
            // NodeId:   1:121
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 542), new Point(385.99997, 543));
            canvas.RestoreState();


            // View:     textView29
            // NodeName: Rafa� Sulowski
            // NodeType: TEXT
            // NodeId:   1:122
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(43, 103, 119);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Bold", 700, FontStyleType.Normal);
            canvas.FontSize = 20f;
            canvas.DrawString(@"Rafa� Sulowski", 19f, 555f, 173f, 24f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     textView30
            // NodeName: rmsulowski@gmail.com, 21 lat, Lublin
            // NodeType: TEXT
            // NodeId:   1:123
            canvas.SaveState();
            canvas.FontColor = Color.FromRgb(178, 198, 213);
            canvas.Alpha = 1;
            canvas.Font = new Microsoft.Maui.Graphics.Font("Inter-Light", 300, FontStyleType.Normal);
            canvas.FontSize = 16f;
            canvas.DrawString(@"rmsulowski@gmail.com, 21 lat, Lublin", 30f, 590f, 277f, 19f, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.RestoreState();


            // View:     lineView9
            // NodeName: Line 10
            // NodeType: LINE
            // NodeId:   1:124
            canvas.SaveState();
            canvas.StrokeColor = Color.FromRgb(154, 154, 154);
            canvas.Alpha = 1;
            canvas.StrokeSize = 2;
            canvas.DrawLine(new Point(7, 621), new Point(385.99997, 622));
            canvas.RestoreState();


            // View:     frameView31
            // NodeName: plus-circle 3
            // NodeType: FRAME
            // NodeId:   1:125
            canvas.SaveState();
            canvas.RestoreState();


        }
    }
}