# UnityPlayer Window Visual
<img alt="トップ画像" src="https://github.com/user-attachments/assets/c275efca-48da-49b6-84e3-762cbcbdfdee" />

## 概要 / Overview
Windows11で動作するUnityのスタンドアロンプレイヤーのウィンドウの見た目を変更する機能を提供します
(導入したプロジェクトをビルドしたWindows用のプレイヤーアプリケーションでのみ機能します)

Change Standalone Player window visual running on Windows11
(This feature only works for Windows player applications built with the installed project)

## 動作環境 / Requirements
- Windows 11(21H2以上)
  
  Windows 11 (version 21H2 or later)


- Unity 2021.3以上
  
  Unity 2021.3 or later

- Api Compatibility Level: .NET Standard 2.1 
  

## 動作を確認した環境 / Verified Environment
- Windows 11 24H2 (26100)
- Unity 2021.3.45f1, Unity 2022.3.62f1, Unity 6000.0.54f1, Unity 6000.1.13f1

## 使用方法 / English "Usage" is below this
### ウィンドウの縁
#### ウィンドウの縁の色を変更する
名前空間`HW.UnityPlayerWindowVisual`内の`WindowBorderColor.Set`を実行すると、ウィンドウの縁の色を任意の色に変更することができます

引数には`UnityEngine.Color`または`UnityEngine.Color32`（推奨）で縁の色を指定します
```csharp
// スタンドアロンプレイヤーのウィンドウの縁を赤くする例
HW.UnityPlayerWindowVisual.WindowBorderColor.Set(new UnityEngine.Color32(255, 0, 0));
```

#### ウィンドウの縁の色を既定値に戻す
名前空間`HW.UnityPlayerWindowVisual`内の`WindowBorderColor.SetDefault`を実行すると、ウィンドウの縁の色を既定値に戻すことができます
```csharp
// スタンドアロンプレイヤーのウィンドウの縁をOSの既定の色に戻す
HW.UnityPlayerWindowVisual.WindowBorderColor.SetDefault();
```

#### ウィンドウの縁を非表示にする
名前空間`HW.UnityPlayerWindowVisual`内の`WindowBorderColor.SetNoneBorder`を実行すると、ウィンドウの縁を非表示にすることができます
```csharp
// スタンドアロンプレイヤーのウィンドウの縁を描画しないようにする
HW.UnityPlayerWindowVisual.WindowBorderColor.SetNoneBorder();
```
以下の画像は左側が縁あり（水色に設定）で、右側が縁なし（`SetNoneBorder`実行後）です

<img alt="縁ありと既定値の比較" src="https://github.com/user-attachments/assets/243e9878-1b81-4719-b340-0cc8b3ea1806" />

### ウィンドウのタイトルバー
#### ウィンドウのタイトルバーの色を変更する
名前空間`HW.UnityPlayerWindowVisual`内の`WindowTitlebarColor.Set`を実行すると、ウィンドウのタイトルバーの色を任意の色に変更することができます

引数には`UnityEngine.Color`または`UnityEngine.Color32`（推奨）でタイトルバーの色を指定します
```csharp
// スタンドアロンプレイヤーのウィンドウのタイトルバーを青くする例
HW.UnityPlayerWindowVisual.WindowTitlebarColor.Set(new UnityEngine.Color32(0, 0, 255));
```

#### ウィンドウのタイトルバーの色を既定値に戻す
名前空間`HW.UnityPlayerWindowVisual`内の`WindowTitlebarColor.SetDefault`を実行すると、ウィンドウのタイトルバーの色を既定値に戻すことができます
```csharp
// スタンドアロンプレイヤーのウィンドウのタイトルバーの色をOSの既定の色に戻す
HW.UnityPlayerWindowVisual.WindowTitlebarColor.SetDefault();
```

### ウィンドウのタイトルバーの文字列
#### ウィンドウのタイトルバーの文字色を変更する
名前空間`HW.UnityPlayerWindowVisual`内の`WindowTitlebarTextColor.Set`を実行すると、ウィンドウのタイトルバーの文字色を任意の色に変更することができます

引数には`UnityEngine.Color`または`UnityEngine.Color32`（推奨）でタイトルバーの文字色を指定します
```csharp
// スタンドアロンプレイヤーのウィンドウのタイトルバーの文字を緑色にする例
HW.UnityPlayerWindowVisual.WindowTitlebarTextColor.Set(new UnityEngine.Color32(0, 255, 0));
```

#### ウィンドウのタイトルバーの文字色を既定値に戻す
名前空間`HW.UnityPlayerWindowVisual`内の`WindowTitlebarTextColor.SetDefault`を実行すると、ウィンドウのタイトルバーの文字色を既定値に戻すことができます
```csharp
// スタンドアロンプレイヤーのウィンドウのタイトルバーの文字色をOSの既定の色に戻す
HW.UnityPlayerWindowVisual.WindowTitlebarTextColor.SetDefault();
```

### 複数の色を同時に変更する
本機能には、ウィンドウの周囲（縁とタイトルバー）、タイトルバー全体（タイトルバーとタイトル文字列）および3項目すべてをまとめて変更する機能が用意されています

上記の単体の色の操作と同様に、任意の色の設定（`Set`メソッド）とOS既定色の設定（`SetDefault`メソッド）を使用できます
```csharp
// スタンドアロンプレイヤーのウィンドウの縁とタイトルバーの色を黄色くする例
HW.UnityPlayerWindowVisual.WindowAroundColors.Set(new UnityEngine.Color32(255, 255, 0));

// スタンドアロンプレイヤーのウィンドウのタイトルバーを黒く、タイトルバーの文字色を赤くする例
HW.UnityPlayerWindowVisual.WindowTitlebarColors.Set(new UnityEngine.Color32(0, 0, 0), new UnityEngine.Color32(255, 0, 0));

// スタンドアロンプレイヤーのウィンドウの縁とタイトルバーの文字色を赤く、タイトルバーを黒くする例
HW.UnityPlayerWindowVisual.WindowColors.Set(new UnityEngine.Color32(255, 0, 0), new UnityEngine.Color32(0, 0, 0), new UnityEngine.Color32(255, 0, 0));
```
ウィンドウの縁とタイトルバーの色を同時に設定する機能では、それぞれに同じ色に指定する場合は引数を1個省略できるようになっています

### 非対応環境で実行した時のログの出力を設定する
名前空間`HW.UnityPlayerWindowVisual`内の`FeatureUtil.IsOutputLog`(`bool`型のプロパティ)に値を設定すると、Windows11以前以外の非対応環境で実行した時に警告ログを出力するかを設定できます

## Usage / 日本語の「使用方法」は上にあります
### Window border
#### Change Standalone Player window border color
Call `WindowBorderColor.Set`(namespace: `HW.UnityPlayerWindowVisual`) to change Standalone Player window border color to any color

Argument:
- Border color (`UnityEngine.Color` or `UnityEngine.Color32`(recommended))
```csharp
// Color to Standalone Player window border red
HW.UnityPlayerWindowVisual.WindowBorderColor.Set(new UnityEngine.Color32(255, 0, 0));
```

#### Restore Standalone Player window border color to system default
Call `WindowBorderColor.SetDefault`(namespace: `HW.UnityPlayerWindowVisual`) to restore Standalone Player window border color to default
```csharp
// Restore Standalone Player window border color to default
HW.UnityPlayerWindowVisual.WindowBorderColor.SetDefault();
```

#### Hide Standalone Player border
Call `WindowBorderColor.SetNoneBorder`(namespace: `HW.UnityPlayerWindowVisual`) to hide Standalone Player window border
```csharp
// Set a Standalone Player to not display window border
HW.UnityPlayerWindowVisual.WindowBorderColor.SetNoneBorder();
```
The picture below shows the left one with a border(color to skyblue) and the right one without a border(after calling `SetNoneBorder`)

<img alt="縁ありと既定値の比較" src="https://github.com/user-attachments/assets/243e9878-1b81-4719-b340-0cc8b3ea1806" />

### Window titlebar background
#### Change Standalone Player window titlebar background color
Call `WindowTitlebarColor.Set`(namespace: `HW.UnityPlayerWindowVisual`) to change Standalone Player window titlebar background color to any color

Argument:
- Titlebar background color (`UnityEngine.Color` or `UnityEngine.Color32`(recommended))
```csharp
// Color to Standalone Player window titlebar blue
HW.UnityPlayerWindowVisual.WindowTitlebarColor.Set(new UnityEngine.Color32(0, 0, 255));
```

#### Restore Standalone Player window titlebar background color to system default
Call `WindowTitlebarColor.SetDefault`(namespace: `HW.UnityPlayerWindowVisual`) to restore Standalone Player window titlebar background color to default
```csharp
// Restore Standalone Player window titlebar background color to default
HW.UnityPlayerWindowVisual.WindowTitlebarColor.SetDefault();
```

### Window titlebar text
#### Change Standalone Player window titlebar text color
Call `WindowTitlebarTextColor.Set`(namespace: `HW.UnityPlayerWindowVisual`) to change Standalone Player window titlebar text color to any color

Argument:
- Titlebar text color (`UnityEngine.Color` or `UnityEngine.Color32`(recommended))
```csharp
// Color to Standalone Player window titlebar text green
HW.UnityPlayerWindowVisual.WindowTitlebarTextColor.Set(new UnityEngine.Color32(0, 255, 0));
```

#### Restore Standalone Player window titlebar text color to system default
Call `WindowTitlebarTextColor.SetDefault`(namespace: `HW.UnityPlayerWindowVisual`) to restore Standalone Player window titlebar text color to default
```csharp
// Restore Standalone Player window titlebar text color to default
HW.UnityPlayerWindowVisual.WindowTitlebarTextColor.SetDefault();
```

### Set multiple color at the same time
This package has multiple-color setting mode below...
- Border color and titlebar background color
- Titlebar background color and text color
- Border color, titlebar background and text color

As with single-color setting mode, can use `Set` method(set any color) and `SetDefault` method(restore color to default)
```csharp
// Color to Standalone Player window border and titlebar green
HW.UnityPlayerWindowVisual.WindowAroundColors.Set(new UnityEngine.Color32(255, 255, 0));

// Color to Standalone Player window titlebar black and color to Standalone Player window titlebar text red
HW.UnityPlayerWindowVisual.WindowTitlebarColors.Set(new UnityEngine.Color32(0, 0, 0), new UnityEngine.Color32(255, 0, 0));

// Color to Standalone Player window border and titlebar text red and color to Standalone Player window titlebar black
HW.UnityPlayerWindowVisual.WindowColors.Set(new UnityEngine.Color32(255, 0, 0), new UnityEngine.Color32(0, 0, 0), new UnityEngine.Color32(255, 0, 0));
```
Tips: If you color to same color between border and titlebar, you can skip one argument

### Configure log output when executing in unsupported environments
Set `bool` value to `FeatureUtil.IsOutputLog` property (namespace: `HW.UnityPlayerWindowVisual`), configure warning log when executing in unsupported environments without old Windows environment. 

## 導入方法 / English "How to introduction" is below this
1. Gitをインストールする
2. 追加したいプロジェクトを開き、Package Managerを開く
3. 以下のGit URLをコピー、またはこのページ上部の「<> Code」からClone URLをコピーする

   https://github.com/HWataame/UnityPlayerWindowVisual.git

4. 「Package Manager」ウィンドウの左上の「＋」ボタンをクリックし、「Install package from git URL...」を選択する

    <img alt="導入方法01" src="https://github.com/user-attachments/assets/fc8c6d6e-93aa-464b-9415-7fa29be674ea" />
5. 入力欄に手順2でコピーしたURLを貼り付け、「Install」ボタンを押す

    <img alt="導入方法02" src="https://github.com/user-attachments/assets/8f5e7b96-ea77-4483-af57-1be2aa120aa2" />
6. (必要に応じて)Assembly Definition Assetの管理下のエディターコードで利用する場合は、`HW.UnityPlayerWindowVisual`をAssembly Definition Referencesに追加する

    <img alt="導入方法03(必要に応じて)" src="https://github.com/user-attachments/assets/0f520389-ea2a-442f-ac3f-24a82ee7e69b" />

## How to introduction / 日本語の「導入方法」は上にあります
1. Install Git to your computer.
2. Open Package Manager in the Unity project to which you want to add this feature.
3. Copy the following Git URL, or copy the Clone URL from "<> Code" at the top of this page

   https://github.com/HWataame/UnityPlayerWindowVisual.git

4. Click the "+" button in the "Package Manager" window and select "Install package from git URL...".

    <img alt="導入方法01" src="https://github.com/user-attachments/assets/fc8c6d6e-93aa-464b-9415-7fa29be674ea" />
5. Paste the URL copied in Step 2 into the input field and press the "Install" button.

    <img alt="導入方法02" src="https://github.com/user-attachments/assets/8f5e7b96-ea77-4483-af57-1be2aa120aa2" />
6. (If necessary) For use in editor code under the control of Assembly Definition Asset...

   Add `HW.UnityPlayerWindowVisual` to "Assembly Definition References" in your Assembly Definition Asset.

    <img alt="導入方法03(必要に応じて)" src="https://github.com/user-attachments/assets/0f520389-ea2a-442f-ac3f-24a82ee7e69b" />

## ライセンス / License
[MITライセンス](/LICENSE)です

Using ["MIT license"](/LICENSE)
