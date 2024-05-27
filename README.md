# NEMESYS - A website with ASP.NET MVC C# Framework
The website contains Reports and Investigations, their models, ViewModels and Views.

## Controllers
 - HomeController
   - Index
   - Dashboard
   - About
 - ReportController
   - Index - view a list of reports
   - Create - create a report
   - Edit - edit a report
   - Details - view a report
 - InvestigationController
   - Index - redundant action, left for future possible usability
   - Create - create an investigation
   - Edit - edit an investigation
   - Details - view an investigation

Contains similar Views to accompany these controllers as per the MVC standard. There are also associated ViewModels to create and edit reports and investigations.

## Website under the reporter role
The reporter can view all reports and create and edit a report.

## Website under the investigator role
The investigator can view all reports and upon opening a report, an investigation can be created or edited.

## More components
 - Identity Pages to allow the website to be user-specific i.e. introduce 
 - Razor Pages for Server-Side Scripting of HTML
 - Migrations to update the database. Allow to roll back a version or add a new version/migration.

## More notes
Different environments are introduced such as Development, Staging and Production. We focused on the Development environment.
