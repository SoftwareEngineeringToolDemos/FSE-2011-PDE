#Desktop Location
$desktop = [Environment]::GetFolderPath("Desktop")

# Copy Files
Copy-Item -path c:\vagrant\files\* -Destination $desktop -Recurse

# Create Shortcuts
$WshShell = New-Object -ComObject WScript.Shell
$Shortcut = $WshShell.CreateShortcut("$desktop\Family Tree Demo.lnk")
$Shortcut.TargetPath = "$desktop\Demo Executables\PDE 2 FamilyTree DSL (WPF Application) - Editor\Editor\PDE 2 FamilyTree DSL\Tum.FamilyTreeDSL.exe"
$Shortcut.Save()

$Shortcut = $WshShell.CreateShortcut("$desktop\State Machine Demo.lnk")
$Shortcut.TargetPath = "$desktop\Demo Executables\PDE 2 State Machine Language - Editor\Editor\Editor\StateMachineDSL.exe"
$Shortcut.Save()

$Shortcut = $WshShell.CreateShortcut("$desktop\VModelXt Demo.lnk")
$Shortcut.TargetPath = "$desktop\Demo Executables\PDE V-Modell XT Editor 0.9.9\PDE V-Modell XT Editor 0.9.9\Tum.VModellXT.exe"
$Shortcut.Save()
