   M S B A M L   `   `   `  ����F  BIT_services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:IT_services.ViewIT_services.View  5   	   =#clr-namespace:IT_services.ViewModelIT_services.ViewModel  5   
   #    IT_services.View.CustomerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:IT_services.View     5   	   9	viewmodel#clr-namespace:IT_services.ViewModel     5   
     � Title$  Головне вікно��5	   	   $��534.586��6   $��1101.128��60    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � -   5        $
��CusV��5      $��0,0,3.4,-0.2q�6    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6    � DataContext 5   
   -  'IT_services.ViewModel.CustomerViewModel  5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $	��dgC��5         AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  $
��Left=�6�   $	��195��6�   $��
26,126,0,0q�6�   $	��Top=�6�   $
��1021��6�   ��6   �� *OrderSpisok+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 10 64   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6?   �� *id+  5      $ 
Назва��6%   $		 200 64   
 6@   �� *name+  5      $ Від��6%   $		 150 62   
 6>   �� *start+  5      $
 До��6%   $		 150 61   
 6=   �� *konets+  5      $ 
Місто��6%   $		 150 64   
 6@   �� *city+  5      $ Ціна��6%   $		 150 63   
 6?   �� *price+  5      $ Виконавець:��6%   $		 150 6:   
 6F   �� *name1+  5      $ Телефон��6%   $		 150 66   
 6B   �� *phone+  5      $ Опис��6%   $		 200 63   
 6?   �� *
decription+  5      $ Статус:��6%   $		 150 66   
 6B   �� *status+  5       $ 	Дата:��6%   $		 150 64   
 6@   �� *date+5"      �� 5#   
   $��Видалити��6   $
��Left=�6�   $��
26,382,0,0q�6�   $	��Top=�6�   $	��185��6�   $��50��6�    J� RenderTransformOrigin$ 0.121,0.513&�6  $��Arial)�6*  $��16(�6=  ��6$   �� *Delete+��6?   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �6=  �� 5$   
   $��Пошук послуги��6   $
��Left=�6�   $��
826,20,0,0q�6�   $	��Top=�6�   $	��221��6�   $��50��6�   $��Arial)�6
  $��16(�6  ��6)   �� *Poisk+��6C   ��  �� *FindAncestor+" �6  �� 5%   
   $!��Мої замовлення��6   $
��Left=�6)   $��
446,87,0,0q�6D   $	��Top=�6X   $��Arial)�6p   $��20(�6�   $ 0.983,0.501&�6�   �� 5&   
   $
��Left=�62   $��27��6M   $��
128,25,0,0q�6Y   $
��Wrap=�6m   $	��Top=�6�   $	��120��6�   $��Arial)�6�   $��16(�6�   ��6   �� *nameCustomer+6�   �� 5'   
   $��Користувач:��6   $
��Left=�6&   $��50��6A   $��	26,20,0,0q�6M   $	��Top=�6`   $	��107��6x   $��Arial)�6�   $��16(�6�   5)      5*      