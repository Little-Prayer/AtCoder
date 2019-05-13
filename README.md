# AtCoder回答状況、参考ページなど

## AtCoder Begginers Contest

### ABC051

#### C - Back and Forth

- 自力AC、だいぶベタな実装になったけど、もっとエレガントに行けそう
- というか今の300点より難易度低くないか？

#### D - Candidates of No Shortest Paths

- 解説とかグダグダ見てAC、Warshall-Floyd法は初めて知った。これ本当に網羅できるの？
- 「各頂点間の最短距離を計算し、辺の長さ＜両端間の最短距離となる辺の数を求める」というアイデアはすぐ思いついたものの、各頂点間の最短距離を計算するアルゴリズムがわからずググる羽目に
- dijkstra、そういや忘れてるしコードを書いたこと無いので一回何か解きたい
- Warshall-Floyd法、経由を3重forの頭に置かないと漏れる、これでめちゃくちゃ苦戦した。
- あとC#、intの範囲外にはみ出ても無言でマイナスになるだけでエラー吐いてくれないのな……

### ABC057

#### C - Digits in Multiplication

- 自力AC、300点は楽に解けるときと解けないときの差が極端
- 約数探索、エレガントな方法がありそうで見つからない

### ABC120

#### D-Decayed Bridge

- 解説見た
- <https://qiita.com/ofutonfuton/items/c17dfd33fc542c222396>

~~~Csharp
int x;
int y;
long = x * y;
~~~

でxyがintの範囲外だと事故るという知見。

### ABC122

#### C- GeT AC

- 自力AC
- 累積和で楽勝、添字の扱いが微妙に面倒
- <https://qiita.com/drken/items/56a6b68edef8fc605821>

### ABC124

#### A - Buttons

#### B - Great Ocean View

- 余裕の自力AC

#### C Coloring Colorfully

- 自力AC、参加してないときに限って解けるC問題が来る

#### D - Handstand

- 解説見た、アルゴリズム自体より細かい処理に苦戦するパターン

### ABC125

#### A - Biscuit Generator

- 脳が寝てたので何故かFor文を回してしまう、まあ余裕AC

#### B - Resale

- 脳が起きてたので問題なくAC
- Linqで解き直したさある

#### C - GCD in Blackbord

- 実質的な今回のD問題
- 力技DP、初期条件の設定がうまく行かず、あまりエレガントとはいい難いコードに

#### D - Flipping Signs

- 実質的な今回のC問題、実際コレよりキツいCは普通に割とある気がする。
- エレガントな解法なんか思いつかなかったので力技DPですよ、まあそれでも何とかなってしまう程度には易問

### AGC033

#### A - Darker and Darker

- 解説見た
- AtCoder環境ってTuple使えないのか……
- 配列絡みの凡ミスやめたい

### Edudational DP Contest

#### A-E問題

- ↓を読みながらチマチマと、ほとんど参考コードをC#にコンバートしてるだけ感
- <https://qiita.com/drken/items/dc53c683d6de8aeacf5a#d-%E5%95%8F%E9%A1%8C---knapsack-1>