# System Configuration Wizard Setup

This guide provides instructions on how to set up, build, and run the WPF application using the .NET CLI.

## Directory Structure
To successfully run `dotnet build`, ensure your files are placed in a flat directory structure. All files should be in the same folder where you run the `dotnet` commands.

The directory should look exactly like this:
```
SystemConfigWizard/
├── App.xaml
├── App.xaml.cs
├── app.manifest
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── ProjectSetup.md
├── SystemConfigWizard.csproj
├── key10home.txt
├── key10pro.txt
├── key11home.txt
├── key11pro.txt
├── key7home.txt
└── key7pro.txt
```

## Prerequisites
- Windows OS (WPF applications only run on Windows).
- .NET 8.0 SDK (or newer).

## Step 1: Create the Project Structure
1. Create a new folder named `SystemConfigWizard`.
2. Place all the files listed in the directory structure above into this folder.

## Step 2: Create Mock Text Files
The application expects token text files in the same directory as the executable. Ensure you have created the following text files in the root folder alongside the source code:
- `key7pro.txt`
- `key7home.txt`
- `key10pro.txt`
- `key10home.txt`
- `key11pro.txt`
- `key11home.txt`

Add some token strings (one per line) to these files. To simulate a valid token, add the word `successfully` or `успешно` to one of the lines.
The `.csproj` file is configured to automatically copy these `.txt` files to the output directory during the build process.

## Step 3: Build the Application
Open a command prompt or terminal in the `SystemConfigWizard` folder and run the following command:
```bash
dotnet build
```

## Step 4: Run the Application
You can run the application directly using the .NET CLI:
```bash
dotnet run
```
Alternatively, you can navigate to the output directory (usually `bin/Debug/net8.0-windows/`) and double-click `SystemConfigWizard.exe`.

**Note on UAC (Administrator Privileges):**
Because the application is configured with `app.manifest` to require Administrator privileges, Windows will prompt you with a User Account Control (UAC) dialog when running the application. You must click **Yes** to allow the application to start.

## Step 5: Test the Wizard
1. The wizard window will open.
2. Select the "System Version" (e.g., Version 10) and click "Далее".
3. Select the "Environment Tier" (e.g., Pro) and click "Далее".
4. Click the "Запустить" button to run the validation logic against the corresponding text file (e.g., `key10pro.txt`).