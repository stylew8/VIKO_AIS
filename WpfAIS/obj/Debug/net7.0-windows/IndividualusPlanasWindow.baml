   M S B A M L   `   `   `  ����A  =WpfAIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAISWpfAIS  5   	   %    WpfAIS.IndividualusPlanasWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfAIS     5   	     � Title$	  AIS��5   	   $	��900��6   $
��1600��6"    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ 	/logo.ico��5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   �� $��
644,55,0,0q�6   $��
/logoo.png��6$   $
��Fill=�68   $
��Left=�6G   $	��312��6b   $	��156��6n   $	��Top=�6{   �� 5   
   	 �� X1$ 1��6   	 �� Y1$ 0��6   	 �� X2$
 1600��6   $��2��6'   $��
-1,216,0,0q�6;   $��12��6O   $	��Top=�6[   $
��Left=�6s   $
��1602��6�   ��5      �� 5       �� 
StartPoint$ 0,0.5&�6&    �� EndPoint$ 1,0.5&�69   .��5      � 	 � Color$	 	#FF44B46E��6#   � 5      $	 	#FF005AAB��6#   
 � Offset$
 0.627Q�65   � 5      $	 	#FF29BFCF��6#   $
 0.373Q�65   5      5      �� 5   
   $��
Atsijungti��6   $
��Left=�6&   $��1493,10,0,0q�6A   $��89��6V   ���	#FFFFF2F2���	#FFFFF9F9 � Cursor$
 Hand��6�   $��32��6�   $	��Top=�6�   ��5      �� 5       �� 
TargetType" ��6"   .R�5      ��  �� CornerRadius$ 10��6   $��1q�6/   
����������	#FF206FB6._�5      �� $��Center=�6+   $��Center=�6H   5      5      5      �� 5    
   -   5         ��Name$ btnKont��5       $��Kontantinė informacija��6"   $
��Left=�6C   $��1014,184,0,0q�6^   $	��134��6t   
����������	#FFFFF9F9$
 Hand��6�   $��32��6�   $	��Top=�6�   ���	#FF206FB6��5!      �� 5"      " ��6"   .R�5#      �� $ 10��6   $��1q�6/   
����������	#FF206FB6._�5$      �� $��Center=�6+   $��Center=�6H   5%      5&      5(      �� 5)   
   -   5         ��Name$ txtprisijungtas��5)      $%��Pareigos: kodas, Pavarde Vardas��6)   $
��Left=�6S   $��29��6n   $��
15,182,0,0q�6z   $	��Top=�6�   $	��285��6�   ���	#FF42B5776�   �� 5*   
   -   5        $ txtBla��5*      $���zind.kodas(ID), Pavarde Vardas
................. fakultetas
Studijų programa:Studiju programa 
Akademinė grupė: Grupe��6    $
��Left=�6�   $	��176��6�   $��
56,285,0,0q�6�   $	��Top=�6�   $	��340��6  $
��Bold"�6  �� 5+   
   $!��Individualus studiju planas��6   $
��Left=�66   $��
31,246,0,0q�6Q   $	��Top=�6e   $��18(�6}   $
��Bold"�6�   �� 5,   
   -   5        $ txtMetai��5,      $��20**/20** m. m��6"   $
��Left=�6;   $��43��6V   $��416,263,0,0q�6b   $	��Top=�6w   $	��114��6�   �� 5-   
   $��Rudens semestras:��6   $
��Left=�6,   $��416,311,0,0q�6G   $	��Top=�6\   �� 5.   
   $��Pavasario semestras:��6   $
��Left=�6/   $��416,554,0,0q�6J   $	��Top=�6_   &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ 	dtgRudens��50         CanUserAddRows$ False��6&      CanUserDeleteRows$ False��6=      CanUserResizeColumns$ False��6W      CanUserResizeRows$ False��6t      AutoGenerateColumns$ False��6�   $	��200��6�   $��416,342,519,342q�6�   
�������   GridLinesVisibility$	 All=�51         HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Dalyko pavadinimas��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Name+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  55      $ Tarpiniai įvertinimai��6)   $ * 6H      CellTemplate 56      �� 57      .R�58      �� -   5        $��Paspauskite��58   %   6;   59      5;      5=        5>   
   -   5        $ dtgPavasario��5>      $ False��6)   $ False��6@   $ False��6Z   $ False��6w   $ False��6�   $	��200��6�   $��416,606,519,78q�6�   
�������$	 All=�5?   (   
 �����
 ����� 5A        5B      $ Dalyko pavadinimas��6%   $ 2* 6Z    6A   �� *Name+6Z     5C      $ Tarpiniai įvertinimai��6)   $ * 6H    5D      �� 5E      .R�5F      �� -   5        $��Paspauskite��5F   %   6;   5G      5I      5K      �� 5M   
   -	   5        $ 
btnPagrind��5M      $��Pagrindinis menu��6%   $��Right=�6@   $��0,10,1488,0q�6\   $	��102��6q   ���	#FFFFF2F2���	#FFFFF9F9$
 Hand��6�   $��32��6�   $	��Top=�6�   ��5N      �� 5O      " ��6"   .R�5P      �� $ 10��6   $��1q�6/   
����������	#FF206FB6._�5Q      �� $��Center=�6+   $��Center=�6H   5R      5S      5U      5W      5X      