   M S B A M L   `   `   `  ????E  ATetrisGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TetrisGame
TetrisGame  5   	       TetrisGame.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TetrisGame     5   	   -   5          ? Title$  Tetris??5   	   $	??600??6   $	??800??6%   $	??600??5	   	   $	??600??6   
???????$??segoe UI Light)?5   	   $??28(?6%   .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   ??5   
   ?? 5       ?? ImageSource$ Assets\Background.jpg??6   .+?5   
   (? $??1??6   $??1??6   $??0 , 0 , 0, 20q?6/   .??5      ?? -   5         ??Name$ 
GameCanvas??5      
???   ?$	??250??5      $	??535??5       }?. 5"      5$      ?? 5%   
   -   5         ??Name$ 	ScoreText??5%      $??0??6'   $??1??67   $??Score: ??6D   $
??0,10q?6S    ?? TextAlignment$ Center=?6a   ?? 5&   
   $??1??6   $??2??6"   $??Center=?62   $
??Left=?6M   .+?5'      ?? $
??Next??6   $ Center=?6$   ?? 5(      -   5         ??Name$ 	NextImage??5(      $??20q?6'   $	??120??63   5)      ? 5*   
   -   5         ?Name$ GameOverMenu??5*      $??2??6%   $??3??66   ???	#CC000000$y?Hidden=?6a   .+?5+      ?? $??Center=?6   $??Center=?66   .+?5,      ?? $??	Game Over??6   $??48(?6-   $ Center=?6;   ?? 5-      -   5        $ FinalScoreText??5-      $??Score: ??64   $??36(?6C   $ Center=?6Q   ?? 5.      -   5        $??	Play Agin??5.      
???????$??0,20,0,0q?6E   $??5q?6W   6c   5/      50      51      52      