   M S B A M L   `   `   `  ����A  =WpfAIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAISWpfAIS  5   	       WpfAIS.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	    localclr-namespace:WpfAIS  5   	   -   5          � Title$&   Akademinės informacijos sistema��5	   	   $	��900��61   $
��1600��6>    � WindowStartupLocation$ CenterScreen=�5
   	    � Icon$ 	/logo.ico��5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � -   5         �Name$ txtPassword��5       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��	0,328,0,0q�6   $��43��5   	   $	��Top=�5   	   $��Center=�5   	   $	��248��5   	    �� CornerRadius$ 10��5   	   
�������$��1q�5   	   ._�5      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   5          Name$ txtVar��5   $    �� TextAlignment$ Center=�64   $��Center=�5      $��0q�5      
������ 	   	Watermark$,	 &                      Vartotojo vardas��5       5!      �� 5#   
   $��	0,416,0,0q�6   $��43��5$   	   $	��Top=�5%   	   $��Center=�5&   	   $	��248��5'   	   $ 10��5(   	   
�������$��1q�5*   	   ._�5+      ,  &Xceed.Wpf.Toolkit.WatermarkPasswordBox  -   5        
  Name$
 txtPassword1��5+   (   $��Center=�6>   $��Center=�5,      $��0q�5-      
������ $	 Slaptažodis��5/      50      �� 51   
   $��	0,0,0,673q�6   $��	logoo.png��6#   $
��Fill=�66   $��Center=�6E   $	��312��6b   $	��156��6n   $��Bottom=�6{   �� 52   
   	 �� X1$ 1��6   	 �� Y1$ 0��6   	 �� X2$
 1600��6   $��2��6'   $��	0,216,0,0q�6;   $��12��6N   $	��Top=�6Z   $��Center=�6r   $
��1602��6�   ��53      �� 54       �� 
StartPoint$ 0,0.5&�6&    �� EndPoint$ 1,0.5&�69   .��55      �  � Color$ 	#FF44B46E��6#   � 56      $ 	#FF005AAB��6#    � Offset$ 0.627Q�65   � 57      $ 	#FF29BFCF��6#   $ 0.373Q�65   58      5:      �� 5;   
   -   5         ��Name$ btnPrisijungti��5;      $��Prisijungti��6)   $��Center=�6?   $��44��6\   $��	0,510,0,0q�6h   $	��Top=�6{   $	��124��6�   ���	#FFFFF2F2���	#FFFFF9F9 � Cursor$
 Hand��6�   ��5<      �� 5=       �� 
TargetType" ��6"   .R�5>      �� $ 10��6   $��1q�6/   
���������5?      �� 5@      $ 0,0.5&�62   $ 1,0.5&�6E   .��5A   "   � $ 	#FF44B46E��6/   � 5B   "   $ 	#FF005AAB��6/   $ 0.597Q�6A   � 5C   "   $ 	#FF29BFCF��6/   $ 0.257Q�6A   � 5D   "   $ 	#FE1FA7C6��6/   $ 0.407Q�6A   5E      ._�5G      �� $��Center=�6+   $��Center=�6H   5H      5I      5K      �� 5L   
   -   5         ��Name$ txtForErrors��5L      $�� ��6&   $��Center=�61   $��Center=�6N   $��Center=�6p   $��	0,464,0,0q�6�   $	��Top=�6�   $	��404��6�   ���	#FFEA49496�   5M      5O      