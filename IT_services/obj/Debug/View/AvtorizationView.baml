   M S B A M L   `   `   `  ����F  BIT_services, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:IT_services.ViewIT_services.View  5   	   =#clr-namespace:IT_services.ViewModelIT_services.ViewModel  5   	   '    !IT_services.View.AvtorizationView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:IT_services.View     5   	   9	viewmodel#clr-namespace:IT_services.ViewModel     5   	     � Title$  Вхід��5	   	   $	��450��6   $��494.084��6#    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �  � DataContext 5   
   1  +IT_services.ViewModel.AvtorizationViewModel  5      5      .+�5   
   �� $��Вхід��6   $��0��6   
���   �$��2q�6@   $��112,24,113,0q�6T   $	��Top=�6j   $��Arial)�6�   $��22(�6�   $
��Bold"�6�   $��Center=�6�   $��39��6�   �� 5   
   $��Email��6   $
��Left=�6    $��47,159,0,226q�6;   $��Center=�6Q   $��Arial)�6l   $��19(�6   $
��Bold"�6�   $	��111��6�   $
��Left=�6�   $��35��6�   $��Center=�6�   �� 5   
   $
��Left=�6   
���   �$��2q�6A   $��35��6U   $��192,159,0,0q�6a    �� TextWrapping$
 Wrap=�6v   $	��Top=�6�   $	��240��6�   $��Arial)�6�   $��16(�6�   $��Center=�6�   ��6�   �� *emailE+6�   �� 5   
   $��Пароль��6   $
��Left=�6!   $��47,231,0,154q�6<   $��Center=�6R   $��Arial)�6m   $��19(�6�   $
��Bold"�6�   $	��111��6�   $
��Left=�6�   $��35��6�   G� 5   
   -   5         G�Name$ passwordBox��5      $
��Left=�6+   
���   �$��2q�6Z   $��35��6n   $��192,230,0,0q�6z   $	��Top=�6�   $	��240��6�   $��Arial)�6�   $��16(�6�   $��Center=�6�   �� 5   
   $��Реєстрація��6�   $
��Left=�6�   $��
20,312,0,0q�6�   $	��Top=�6�   $��Arial)�6�   $��22(�6	  
����������	#FF0E2CE8$	��437��6A  $��Center=�6M  
���������6   �� *Registration+��62   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �6q  �� 5   
   $��Підтвердити��6�   
���   �$��2q�6�   $��Right=�6�   $��0,358,108,0q�6�   $	��Top=�6	  $	��268��6!  $��Arial)�6-  $��22(�6@  $
��Bold"�6N  $��39��6`  ��6   �� *Avtorization+��62   ��  �� *FindAncestor+" �6`  �� 5   
   -   5        $��Entrance��5      $
��Left=�6%   $��32��6@   $��
192,94,0,0q�6L   $	��Top=�6`   $	��240��6x   $��Arial)�6�   $��16(�6�   .@�5      �� Виконавець6$   �� 5      Замовник6"   5      �� 5    
   $
��Як��6   $
��Left=�6   $��47,91,0,294q�68   $��Center=�6M   $��Arial)�6h   $��19(�6{   $
��Bold"�6�   $	��111��6�   $
��Left=�6�   $��35��6�   $��Center=�6�   5"      5#      