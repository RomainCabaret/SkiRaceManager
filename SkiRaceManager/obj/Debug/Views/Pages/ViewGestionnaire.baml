   M S B A M L   `   `   `  ����I  ESkiRaceManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SkiRaceManagerSkiRaceManager  5      %    SkiRaceManager.ViewGestionnaire   5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .localclr-namespace:SkiRaceManager     5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5       N� 
Background �#212024  MaterialDesignFont N� 
FontFamily# �  5	      .��5      � $��20q�6    � 	Resources 5   
   (   "SkiRaceManager.DateFormatConverter  DateFormatConverter��%   &	         5      6(   5      .+�5   
   � $	��Top=�6   $��50��6'    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5       �� $��24(�6   $
��Left=�6&   $��Center=�6A   Menu gestionnaire6o   �� 5#      $��10��6   $��1��6    5%      � 5'   
   -   5         �Name$ mainGrid��5'      $��	0,120,0,0q�6"    5(      �� 5)      6%   .+�5+      �� .+�50      �� -   5         ��Name$ RequestListView��50      $��Center=�6U   $��
0,98,10,32q�6s   ��64   �� *
requests+ �� View 51      �� 52      .P�53      �� $��Id��6-   	 �� DisplayMemberBinding	 69   �� *Id+�� 54      $��Piste��6-   	 6<   �� *	SlopeName+�� 55      $��
Demandeurs��6-   	 6A   �� *AccountName+�� 58      $��Date de publication��6-   
 �� CellTemplate
 59   "   �� 5:   &   .R�5;   *   �� ��64   �� *DateDemande+ �� 	Converter# [ 5<   '   5>      �� 5?      $��Traité��6-   	 6=   �� *
IsTraite+5@      5B      5C      5D      5E      5F      