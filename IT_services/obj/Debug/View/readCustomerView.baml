   M S B A M L   `   `   `  ����F  BIT_services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:IT_services.ViewIT_services.View  5   	   =#clr-namespace:IT_services.ViewModelIT_services.ViewModel  5   	   '    !IT_services.View.readCustomerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:IT_services.View     5   	   9	viewmodel#clr-namespace:IT_services.ViewModel     5   	     � Title$  Замовлення��5	   	   $��534.586��6   $��1101.128��6-    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � -   5        $��readCustomerG��5       � ColumnDefinitions 5   
   �� 5      $	��39* �6   �� 5      $
��326* �6    � DataContext 5   
   1  +IT_services.ViewModel.readCustomerViewModel  5      5      .+�5   
   �� $4��.Змінити статус замовленя��6   $
��Left=�6�   $��46��6�   $��709.13,414,0,0q�6�   $	��Top=�6�   $	��232��6  $��Arial)�6  $��16(�62  $��1��6@  ��64   �� *UpdateOrder+��6T   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �6@  &   System.Windows.Controls.DataGrid  5   
   -   5        $	��dgC��5         AutoGenerateColumns .     CanUserDeleteRows .     CanUserAddRows .  $
��Left=�6�   $	��268��6�   $��	58,97,0,0q�6�   $	��Top=�6�   $
��1000��6�   $��2��6�   ��6   �� *SpisokCustomer+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$ 
 Ім'я замовника��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *nameCustomer+  5      $'
 !Телефон замовника��6%   $	 200 6@    6L   �� *phoneCustomer+  5      $
 Email замовника��6%   $	 200 6>    6J   �� *emailCustomer+  5      $
 Дата��6%   $	 200 63    6?   �� *date+  5      $
 Статус��6%   $	 200 65    6A   �� *status+5      �� 5    
   $��Замовлення��6   $
��Left=�6%   $��342.13,26,0,0q�6@   $	��Top=�6W   $��Arial)�6o   $��24(�6�   $��1��6�   5!      5"      