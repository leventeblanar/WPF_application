   M S B A M L   `   `   `  ����  HangszerekApp+    %HangszerekApp.EditRendelesTetelWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$%  Rendelési tétel módosítása��5   	   $	��400��6,   $	��400��69   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��
Rendelés:��6-   $��Center=�6A   �� 5   
   -   5         ��Name$ RendelesDropdown��5   0   $��0��6   $��1��6    60   �� 5   
   $��1��6   $��0��6   $��	Hangszer:��6-   $��Center=�6A   �� 5   
   -   5        $ HangszerDropdown��5   0   $��1��6   $��1��6    60   �� 5   
   $��2��6   $��0��6   $��Mennyiség:��6-   $��Center=�6B   �� 5   
   -   5         ��Name$ MennyisegInput��5   /   $��2��6   $��1��6   6/   �� 5    
   $��3��6   $��0��6   $��Egységár:��6-   $��Center=�6A   �� 5!   
   -   5        $ EgysegarInput��5!   /   $��3��6   $��1��6   6/   �� 5$   
   -   5        $��5��5$      $��0��6   $��2��6.   $��Mentés��6B   $��0,10,0,0q�6l   $��Center=�6~   5%      5&      