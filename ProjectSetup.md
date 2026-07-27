# System Configuration Wizard Setup

This guide provides instructions on how to set up and run the WPF application.

## Prerequisites
- Windows OS
- Visual Studio 2022 (or newer) with ".NET desktop development" workload installed.
- .NET 6.0 SDK (or newer).

## Step 1: Create the Project
1. Open Visual Studio.
2. Select **Create a new project**.
3. Search for **WPF Application** (make sure it's the one for C# and .NET, not .NET Framework unless specifically required, but this code uses modern C#).
4. Name the project `SystemConfigWizard`.
5. Choose .NET 6.0 (or higher) as the target framework.

## Step 2: Add Code Files
1. Replace the contents of `MainWindow.xaml` in your project with the provided `MainWindow.xaml` file.
2. Replace the contents of `MainWindow.xaml.cs` in your project with the provided `MainWindow.xaml.cs` file.

## Step 3: Add Administrator Privileges (Application Manifest)
To ensure the application prompts for User Account Control (UAC) to get Administrator privileges:
1. In the **Solution Explorer**, right-click the project name (`SystemConfigWizard`) -> **Add** -> **New Item...**.
2. Search for "Manifest" and select **Application Manifest File (Windows Only)**. Name it `app.manifest` (or leave the default name) and click **Add**.
3. Replace the contents of `app.manifest` with the provided XML code, which contains:
   ```xml
   <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
   ```
4. Tell the project to use this manifest:
   - Right-click the project -> **Properties**.
   - Navigate to **Application** -> **General** (or just **Application** in older VS versions).
   - Look for the **Manifest** dropdown.
   - Select the `app.manifest` file you just added. (In the `.csproj` file, it will add `<ApplicationManifest>app.manifest</ApplicationManifest>`).

## Step 4: Create Mock Text Files
The application expects text files in the same directory as the executable.
1. Right-click the project -> **Add** -> **New Item...** -> **Text File**.
2. Create the following files:
   - `key7pro.txt`
   - `key7home.txt`
   - `key10pro.txt`
   - `key10home.txt`
   - `key11pro.txt`
   - `key11home.txt`
3. Add some token strings (one per line) to these files. For example, add the word `successfully` to one of the lines to simulate a valid token.
4. For each of these text files:
   - Select the file in **Solution Explorer**.
   - In the **Properties** window, change **Copy to Output Directory** to **Copy if newer** or **Copy always**. This ensures the files are placed next to the `.exe` when you build and run.

## Step 5: Run the Application
1. Press `F5` or click **Start** in Visual Studio.
2. Windows will prompt you with a UAC dialog asking for Administrator permissions. Click **Yes**.
3. The wizard will open. Follow the steps to test the logic.