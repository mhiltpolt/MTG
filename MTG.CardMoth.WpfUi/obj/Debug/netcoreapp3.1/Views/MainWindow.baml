   M S B A M L   `   `   `  ����M  IMTG.CardMoth.WpfUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MTG.CardMoth.WpfUiMTG.CardMoth.WpfUi  5   	   )    #MTG.CardMoth.WpfUi.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MTG.CardMoth.WpfUi     5   	   ���#333333  � Title$  MTG.CardMoth��5	   	   $	��600��6   $	��900��6+   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �  5      �� 5      �� 5      �� 5      .+�5      �� ���#990099$��5q�6+   $��3��6?   �� 5      $��0��5      $��16q�6   ���#999999$��Center=�5   &   $��Center=�6C   $��42(�5      $
��Bold"�6   .��61   Sets67   �� 5      $��1��5       $��16q�6   $��20(�5"      $
��Bold"�6   ��5!      �� *LoadSetsCommand+.��5"   -   	Load Sets68   �� 5#      $��2��5$      $��16q�6    �� DisplayMemberPath$
 Name��5&      $��20(�5(      $
��Bold"�6   $��Center=�6-   ��5%      ��  �� Path$
 Sets� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5'      �� $ 
CurrentSet�5(   -   5)      � 5+   
   $��1��6    5,      �� 5-      �� 5.      �� 5/      .+�51      �� ���#990099$��5q�6+   $��3��6?   �� 52      $��0��53      $��16q�6   ���#999999$��Center=�54   &   $��Center=�6C   $��42(�55      $
��Bold"�6   .��61   Cards68   �� 56      $��1��57      $��16q�6   $��20(�59      $
��Bold"�6   ��58      �� *LoadCardsCommand+.��59   -   
Load Cards69   �� 5:      $��2��5;      $��16q�6   $
 Name��5=      $��20(�5?      $
��Bold"�6   $��Center=�6-   ��5<      �� $ Cards�$ PropertyChanged=� 5>      �� $ CurrentCard�5?   -   5@      �� 5B   
   $��1��68   $��0��6H   $��30q�6U   ��6   �� $ CurrentSet.Icon�6U   �� 5C   
   $��1��6:   $��1��6J   $��30q�6W   ��6   �� $ CurrentCard.Image�6W   5D      5E      