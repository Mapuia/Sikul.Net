   M S B A M L   `   `   `  ����	  sikul$    Sikul.CreateAcademicYearWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Create Academic Year��5   	   $	��250��6&   $	��300��63    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Year:��6   $��0��6    $��0��6-   $��5q�6=   �� 5   
   -   5         ��Name$ YearTextBox��5      $��0��6'   $��1��64   $��5q�6D   �� 5   
   $��Start Date:��6   $��1��6&   $��0��63   $��5q�6C   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ StartDatePicker��5      $��1��6.   $��1��6;   $��5q�6K   �� 5   
   $��	End Date:��6   $��2��6$   $��0��61   $��5q�6A     5   
   -   5        $ EndDatePicker��5      $��2��6,   $��1��69   $��5q�6I   �� 5   
   -   5         ��Name$ CreateButton��5      $��Create��6'   $��3��68   $��1��6E   $��5q�6U   $	��100��6{   $��Right=�6�   5      5      