#Requires -RunAsAdministrator
# Install Hyper-V
Write-Host "Installing Hyper-V"
Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All
Write-Host

# Install apps using Chocolatey
Write-Host "Installing Chocolatey"
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
Write-Host

Write-Host "Installing applications from Chocolatey"
choco feature enable -n allowGlobalConfirmation

# Install docker
cinst docker-for-windows -y