   M S B A M L   `   `   `  ����  DmToEuroBinding     DmToEuroBinding.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  DM ➠ Euro��5   	   $	��150��6"   $	��400��6/   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� $	��DM:��6   �� 5      -   5         ��Name$ 	tbEingabe��5      $��Center=�6)   $	��120��6K    �� TextAlignment$ Right=�6Z   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   $��Center=�6>   .+�5      �� $��Euro:��6   �� 5      
���   �$��1q�6(   $	��120��6<   $��Right=�6K   ��5      ��  �� ElementName$ 	tbEingabe�� �� Path$
 Text�   DmToEuroConverter �� 	Converter# [  5      5      5      