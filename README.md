# ExcelPwdGen

This repository and tool contents are for Japanese only.

パスワード候補を生成して「パスワードを暗号化して保存」を行う Excel 向け [VSTO アドイン](https://learn.microsoft.com/ja-jp/visualstudio/vsto/getting-started-programming-vsto-add-ins?view=vs-2022)

パスワードの必須文字列は 8 字以上 15 字以下で英小大文字と記号を混ぜる。

## なぜ作ったか

- Excel のパスワード暗号化機能はアクセスするのが微妙に面倒
- 比較的安全性の期待できるランダムなパスワード提案機能がない
- Excel は元来あまりパスワード保護機能を使っても多くの人が弱いパスワードにしがちなので、簡単にできれば良いのかなと感じた為
  - また、エクセルファイル内の編集権限だけを操作するパスワード保護機能も別途ある為複雑になりがち(これはセキュリティ的な視点から見れば意味がない機能なので誤解されやすい)
  - 総当たり用ツールが存在しているので脆弱になりがちな為、補助ツールとしてのようなものを想定
- ...という DIY です

## Environment and Build

作者は Windows 11 + Excel 2019 で確認しています

- .NET Framework 4.7.2
- Windows 向け

`Microsoft Visual Studio Tools for Office (VSTO)`コンポーネント導入済みの最新の Visual Studio でビルドします。  
ソリューションにはアドイン用とインストーラ用が含まれます。  
インストーラ作成には[Visual Studio Installer Projects 拡張機能](https://learn.microsoft.com/ja-jp/visualstudio/deployment/installer-projects-net-core?view=vs-2022)を使用します。

## License

MIT です。  
ライセンスの範疇で基本的にはご自由に利用ください。

## Note

本リポジトリはサンプル的です。  
公開リポジトリとして置いておきますが、基本放置になりますのでご容赦ください。
