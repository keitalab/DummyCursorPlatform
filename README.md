# DummyCursorPlatform
実験者フレンドリーなダミーカーソル実験のプラットフォーム
プログラムを変更せずにダミーカーソル実験を設計することができます。

## アプリケーションのダウンロードはこちら
https://drive.google.com/drive/folders/125hbFElN-_z4pgmU-HS1YhNYtptDo6J7

## 実験結果の分析方法
### Excel
- #### 符号付順位和検定   
  1. 対応する2つのデータを隣に並べつつ、縦にデータを並べる。
  ![image](https://user-images.githubusercontent.com/56722185/110085834-ee54b680-7dd4-11eb-8af2-43c9715ae88f.png)
  
  2. 横に並んだデータの差を算出し、その絶対値を求める。  
     ABS関数を使うと便利  
     **ABS(1つ目の値 - 2つ目の値)**
  ![image](https://user-images.githubusercontent.com/56722185/110085452-74bcc880-7dd4-11eb-8551-a8d733b3828f.png)
  
  3. 2で求めた絶対値に昇順で順位をつける。  
     RANK関数を使うと便利  
     **RANK(対象の値, $先頭の横軸$先頭の縦軸：$終端の横軸$終端の縦軸, 1)**  
       > 対象の値は順位を確かめたい値の位置。画像でいうC3  
       > 横・縦軸の値に$をつけて順位を調べる範囲を設定する。今回はC3~C12なので、$C$3:$C$12 となる。  
       > 最後の1は昇順の順位であることを表す。何も書かないor0の場合は降順になる。  
  ![image](https://user-images.githubusercontent.com/56722185/110086917-51931880-7dd6-11eb-8a56-185014b95059.png)
  
  4. (同順位の値がでた場合にはその平均をとる)
     例. 4位が2つある時
     この2つは4位と5位にあたるため、順位は(4+5)/2=4.5とする。
     
  5. 差が負の値の場合、順位にマイナスをつける。
     IF関数を使うと便利  
     **IF(2値の差<0, 順位*-1, そのままの順位)**
     ![image](https://user-images.githubusercontent.com/56722185/110090700-e861d400-7dda-11eb-8b9b-7cdb613bf481.png)
     
  6. 順位の値を2乗した値を用意する。
     順位の列に「^2」をする。
     ![image](https://user-images.githubusercontent.com/56722185/110090944-3b3b8b80-7ddb-11eb-9900-077f34ec93fd.png)

  7. 符号付順位と順位^2の列をそれぞれ合計する。
     SUM関数を使うと便利
     **SUM(先頭の位置:終端の位置)**
     また、符号付の列の合計はマイナスにしなければいけないため、
     ![image](https://user-images.githubusercontent.com/56722185/110091318-ab4a1180-7ddb-11eb-9b13-2d6a4ac783db.png)
     
  8. 


