   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MainMain  5   	       Main.Window1   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Main     5   	   -   5          � Title$  Window1��5   	   $	��720��6   $
��1080��6&    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�5   	   ���	#FF1A2A35.��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   6*   �� 5      6   .+�5   
   � $��0��6   ���	#FF354142 � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5      �� -   5        $��0��5      
������ 
�������$��20(�6Q   
������ .��5      �� $��Click to Save��6   63   5      �� 5      $��1��6   
������ 
�������$��20(�6Q   
������ .��5      �� $��Node Painter��6   62   5      �� 5      $��2��6   
������ 
�������$��20(�6Q   
������ .��5      �� $��Node Linker��6   61   5       A� 5!      ���	#FF0A1A40$��0��6'   $��3��67   $��
0,0,-22,63q�6K   6a   5"      � 5$   
   -   5        $��grigliaImmagine��5$      $��1��6&   $��
260,95,0,0q�64   .+�5%      �� -   5        $��drawingCanvas��5%       K� ZIndex$ 0��6p   .+�5&      �� -   5         ��Name$ image1��5&   '   $
��Fill=�6   $	��472��67   $	��640��6D   $��/output.bmp��6P   �� 5'      -   5         ��Name$ preview��5'      $ 2��6*   $	��472��6;   $	��640��6H   5)      5*      5+      5,      5.      