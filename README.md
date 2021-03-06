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

### ABC126

#### C - Dice and Coin

- 全てのサイコロの出目について目標点を超える確率を愚直に計算あるのみ
- Logを使わず実際に割ってるのはそちらの方が実装がわかりやすいため
- というか最初Logで実装したら回数計算が意味不明になったので諦めた。

#### D - Even Relation

- 適当な頂点からほかの全ての頂点の距離の偶奇を計算し、偶数なら白、奇数なら黒で塗り分け。
- 木なので計算回数＝辺の数＝N-1なので間に合う。
- ロジックは思いついたものの実装が遅れたため本番では間に合わず。
- グラフ探索の実装に苦手意識があるのでdijkstraとかBFSとかもうちょい解きたい

### ABC127

#### C - Prison

- 本番自力AC
- Liの最大値とRiの最小値を取り、Max（Rimin - Limax + 1 , 0)
- 考察・コード化ともに簡単だったが、凡ミスで1RE、つらみ

#### D - Integer Card

- 本番間に合わず、解説見たものの考察自体は合ってたので自力AC
- Priority Queue使ってバカ正直にシミュレートしたら案の定TLE
- Aiを小さい順にCjの大きなものに書き換えていけば良い
- 考慮漏れでRE出てグダグダやってたら時間切れで死

### ABC128

#### C - Switches

- 本番自力(?)AC
- 急にbit全探索とか出てくるものだから慌てて<https://qiita.com/drken/items/7c6ff2aa4d8fce1c9361#bit-%E5%85%A8%E6%8E%A2%E7%B4%A>をパク……参考にして書いた。

#### D - equeue

- 実際にdequeにぶちこんで、全パターン気合の全探索、操作CとDは実質等価である点に注意（一度戻した宝石を再度取るメリットが無いため、左右どちらに入れても同じ）
- Cで時間食ったのも相まって間に合わず、deque自作して復讐予定
- 考察はできたものの、deque持ってなかったから実装がつらみ……
- deque自作してリベンジ達成

### ABC129

<https://atcoder.jp/contests/abc129>

#### A - Airplane

- シンプルにMin(P+Q,Q+R,R+P)、余裕

#### B - Balance

- 累積和、制約的にはベタ実装で行ける気もするけど
- 問題読み違えて（Tを指定した重さだと思ってた）無駄に時間を浪費した

#### C - Typical Stairs

- 変形フィボナッチ、サラッとDP
- steps[i] = steps[i-1] + steps[i-2]、ただし壊れている場合は0
- 考察ができてしまえば実装は楽

#### D - Lamp

- グリッドのすべての地点について、上下左右それぞれに照らせる数を計算し、それら全ての和のMax、それぞれHW回計算するのでO(HW)
- 考察は比較的ラクだが実装ゲー、照らせる数の計算については共通関数化できそうな気はするけど、私の技量では無理。

#### E - Sum Equals Xor

- 「a+b = a XOR b → aとbの2進数表記の各桁が(1,0),(0,0),(0,1)のいずれか」というところまではわかった
- わかったものの計算方法がわからず、解説読んでもわからんので桁DPについて要勉強
- リベンジ達成、ほぼ参考ページのパクリだけど
- 参考：<https://qiita.com/vain0x/items/e74a23d5c62711f95ea0>
- 参考2：<http://drken1215.hatenablog.com/entry/2019/02/04/013700>
- コードフォーマッタ導入

### AGC033

#### A - Darker and Darker

- 解説見た
- AtCoder環境ってTuple使えないのか……
- 配列絡みの凡ミスやめたい

### AGC034

#### A - Kenken Race

- 自力AC
- 考慮漏れでWA出まくり、つら味

#### B - ABC

- 解説読んだ
- ほぼ考察系、実装難易度だとAより楽かも
- テストケースの結果が1個だけint範囲はみ出るっぽいので、intだとAC取れない罠が
- もう全部longでいいんじゃないかな

### ARC037

#### C - 億マス計算

- 解説見てもよくわかんなかったので放置
- 二分探索、理論は知ってるけど実践できない

### Edudational DP Contest

#### A-E問題

- ↓を読みながらチマチマと、ほとんど参考コードをC#にコンバートしてるだけ感
- <https://qiita.com/drken/items/dc53c683d6de8aeacf5a#d-%E5%95%8F%E9%A1%8C---knapsack-1>

### AtCoder300点

#### ABC061 C - Big Array

<https://atcoder.jp/contests/abc061/tasks/abc061_c>

- 自力AC、300点はだいぶ安定してきた
- ↓のEnergyDrinkCollectorとやることはほぼ同じ、↓だと範囲の都合で配列はキツいけど

#### ABC121 C -Energy Drink Collector

<https://atcoder.jp/contests/abc121/tasks/abc121_c>

- 自力AC、PriorityQueue使う意味あった？
- 安い方から順番に買っていって、本数集まったら完了、単純な貪欲
- ぶっちゃけPQ使うより素直にソートしろ

### AtCoder400点

#### ABC054 D - Mixing Experiment

<https://atcoder.jp/contests/abc054/tasks/abc054_d>

- 自力AC、400点もそこそこ自力できてきたかしら
- 変形ナップサック？物質aとbの配合量とそれに対する購入費用の配列を作り、薬品を追加しながら配列を更新していく。
- つまり三重ループなので結構な力技。解説の方法と違い、「i個めの薬品を追加した」という情報を配列に含んでないので、
多重更新しないように最大値から更新したのが私的工夫ポイント

#### ABC061 D - Score Attack

<https://atcoder.jp/contests/abc061/tasks/abc061_d>

- 解説見た、Bellman-Ford法初使用
- ここまで解いた400点では最難な気がする

#### ABC121 D - XOR World

- 自力AC、2進数の各桁ごとに1~A-1と1~Bにおける1の出現回数を計算し、その差を取って奇数ならその桁が1になるという塩梅。
- 考察よりコード化に時間かかった、ループ回数に関しては面倒くさくなった。
- 解説見て愕然ですよ

### AtCoder500点

#### ABC128E - Roadwork

頑張ってみたもののテスト一つだけTLE出るのでお手上げ。  
一旦保留

### 自前ライブラリ

#### 優先度付きキュー

- 参考：<https://ufcpp.net/study/algorithm/col_heap.htm>
- 参考というかパクリ元というか、一応自分で書いてる

#### デック

- 参考：<https://qiita.com/Camypaper/items/de6d576fe5513743a50e#deque>
- 自作とパクリの中間くらいと言い張る

#### UnionFind

- ABC120-Dのときに使ったものを流用、参考ページ<https://qiita.com/ofutonfuton/items/c17dfd33fc542c222396>
