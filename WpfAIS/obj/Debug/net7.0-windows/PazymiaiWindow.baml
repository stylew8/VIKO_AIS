   M S B A M L   `   `   `  ����A  =WpfAIS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAISWpfAIS  5   	       WpfAIS.PazymiaiWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfAIS     5   	   -   5          � Title$	  AIS��5   	   $	��900��6   $
��1600��6"    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ 	/logo.ico��5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dtgPazymiai��5      $	��200��6(   $��416,342,519,342q�65   
�������   GridLinesVisibility$	 All=�5         HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   AutoGenerateColumns$ False��5      	   CanUserAddRows$	 False��5      
   CanUserDeleteRows$
 False��5         CanUserResizeColumns$ False��5         CanUserSortColumns$ False��5         
IsReadOnly$
 True��5       � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�   '        '  t     �� 5      "  6   .�5      ��  � ��$ Center=�6<   �� 5       � ��$ Center=�6C   5      �� 5      "  6   .�5      ��  � ��$ Center=�6<   �� 5       � ��$ Center=�6C   5       5!         Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Aprasymas��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	Procentas+   HeaderStyle 5&      �� 5'      "  6    .�5(      ��  � ��$ Center=�6K   5)         	CellStyle 5+      �� 5,      "  6    .�5-      ��  � ��$ Center=�6K   5.      50        53      $ 
Procentras��6%   $ * 6Y    69   �� *Description+ 54      �� 55      "  6    .�56      ��  � ��$ Center=�6K   57       59      �� 5:      "  6    .�5;      ��  � ��$ Center=�6K   5<      5>        5A      $
 Mark��6%   $ * 6L    63   �� *Mark+ 5B      �� 5C      "  6    .�5D      ��  � ��$ Center=�6K   5E       5G      �� 5H      "  6    .�5I      ��  � ��$ Center=�6K   5J      5L        5O      $ 
DateOfMark��6%   $ * 6X    69   �� *
DateOfMark+ 5P      �� 5Q      "  6    .�5R      ��  � ��$ Center=�6K   5S       5U      �� 5V      "  6    .�5W      ��  � ��$ Center=�6K   5X      5Z      5\      �� 5^   
   $��0,55,0,0q�6   $��
/logoo.png��6"   $
��Fill=�66   $��Center=�6E   $	��312��6b   $	��156��6n   $	��Top=�6{   �� 5_   
   	 �� X1$ 1��6   	 �� Y1$ 0��6   	 �� X2$
 1600��6   $��2��6'   $��	0,216,0,0q�6;   $��12��6N   $	��Top=�6Z   $��Center=�6r   $
��1602��6�   ��5`      �� 5a       �� 
StartPoint$ 0,0.5&�6&    �� EndPoint$ 1,0.5&�69   .��5b      �  � Color$ 	#FF44B46E��6#   � 5c      $ 	#FF005AAB��6#    � Offset$ 0.627Q�65   � 5d      $ 	#FF29BFCF��6#   $ 0.373Q�65   5e      5g      �� 5h   
   -   5         ��Name$ btnAtsijungti��5h      $��
Atsijungti��6(   $
��Left=�6=   $��1493,10,0,0q�6X   $��89��6m   ���	#FFFFF2F2���	#FFFFF9F9  � Cursor$
  Hand��6�   $��32��6�   $	��Top=�6�   ��5i      �� 5j      ! �� 
TargetType"! ��6"   .R�5k      �� " �� CornerRadius$" 10��6   $��1q�6/   
����������	#FF206FB6._�5l      �� $��Center=�6+   $��Center=�6H   5m      5n      5p      �� 5q   
   -   5        $ btnKont��5q      $��Kontantinė informacija��6"   $
��Left=�6C   $��1014,184,0,0q�6^   $	��134��6t   
����������	#FFFFF9F9$
  Hand��6�   $��32��6�   $	��Top=�6�   ���	#FF206FB6��5r      �� 5s      "! ��6"   .R�5t      �� $" 10��6   $��1q�6/   
����������	#FF206FB6._�5u      �� $��Center=�6+   $��Center=�6H   5v      5w      5y      �� 5z   
   -   5        # ��Name$# txtprisijungtas��5z      $%��Pareigos: kodas, Pavarde Vardas��6)   $
��Left=�6S   $��29��6n   $��
15,182,0,0q�6z   $	��Top=�6�   $	��285��6�   ���	#FF42B5776�   �� 5{   
   -   5        $ btnIndPlanas��5{      $��Pagrindinis menu��6'   $��Right=�6B   $��0,10,1476,0q�6^   $	��114��6s   ���	#FFFFF2F2���	#FFFFF9F9$
  Hand��6�   $��32��6�   $	��Top=�6�   ��5|      �� 5}      "! ��6"   .R�5~      �� $" 10��6   $��1q�6/   
����������	#FF206FB6._�5      �� $��Center=�6+   $��Center=�6H   5�      5�      5�      5�      5�      