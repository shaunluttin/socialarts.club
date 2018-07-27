#
# This script currently augments the deploy.cmd script.
#

Remove-Item app.db -ErrorAction Ignore
dotnet ef database update
