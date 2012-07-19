/*
	BreadCrumbs.js
	Errol Sayre
	esayre@olemiss.edu
	
	Provided by the Office of Research and Sponsored Programs
	The University of Mississippi
	
	This script is free to be used but provides no warranty of function or quality.
*/

// BreadCrumb configuration
// set up the site prefix
var sitePrefix = "/pharmacology/";
	// Please note that we don't use the whole prefix, just the important
	//	part that we need for the server so as to make this script easy for
	//	us to migrate between testing and live server. You can use whatever you
	//	like here.

// set up the bread crumb separator text
var breadCrumbSeparator = " > ";

// set up our list of crumb items
	// The bread crumb items refer to items on your site that require special
	//	labels. You can specify a label specifically using the URI of the
	//	file/folder or generically for all occurences of a file/folder.
var breadCrumbLabels = new Array();
// generic labels
//breadCrumbLabels["staff.html"] = "Staff List";
// specific labels
//breadCrumbLabels["/"] = "My Website";
//breadCrumbLabels["images/"] = "Images Folder";
breadCrumbLabels["afipiretisantes"] = "Αφυπηρετήσαντες";
breadCrumbLabels["grammateia.html"] = "Γραμματεία";
//breadCrumbLabels["ekpaideush.html"] = "Εκπαίδευση";
breadCrumbLabels["energa_melh"] = "Ενεργά Μέλη";
breadCrumbLabels["epikoinwnia.html"] = "Επικοινωνία";
breadCrumbLabels["ereunhtikoi_tomeis"] = "Ερευνητικοί Τομείς";
breadCrumbLabels["sunergates.html"] = "Συνεργάτες";
breadCrumbLabels["anosofarmakologia"] = "Ανοσοφαρμακολογία";
breadCrumbLabels["daifoti"] = "Ζωή Παπαδοπούλου-Νταϊφώτη";
breadCrumbLabels["galanopoulou"] = "Παναγιώτα Γαλανοπούλου";
breadCrumbLabels["karageorgiou"] = "Χαρίκλεια Καραγεωργίου";
breadCrumbLabels["kardiaggeiako"] = "Καρδιαγγειακό";
breadCrumbLabels["klin_meletes"] = "Κλινικοεργαστηριακές Μελέτες";
breadCrumbLabels["kyttariko_stress"] = "Κυτταρικό stress";
breadCrumbLabels["liapi"] = "Χάρις Λιάπη";
breadCrumbLabels["links.html"] = "Links";
breadCrumbLabels["messari"] = "Ιωάννα Μεσσάρη";
breadCrumbLabels["neuro_psycho"] = "Νευροφαρμακολογία-Ψυχοφαρμακολογία";
breadCrumbLabels["pantos"] = "Κωνσταντίνος Πάντος";
breadCrumbLabels["papadopoulos"] = "Γεώργιος Παπαδόπουλος";
breadCrumbLabels["sitaras"] = "Νικόλαος Σιταράς";
breadCrumbLabels["tesseromati"] = "Χριστίνα Τεσσερομάτη";
breadCrumbLabels["tiligada"] = "Αικατερίνη Τυλιγάδα";
breadCrumbLabels["ekpaideush"] = "Εκπαίδευση";
breadCrumbLabels["Anakoinwseis"] = "Ανακοινώσεις";
breadCrumbLabels["erg_fysiol"] = "Εργ. Φυσιολ. Καρδιάς-Αγγείων";
breadCrumbLabels["erg_kyttaro"] = "Εργ. Κυτταροκαλλιεργειών";
breadCrumbLabels["erg_mor_viol"] = "Εργ. Μοριακής Βιολογίας";
breadCrumbLabels["dalla"] = "Χριστίνα Δάλλα";
breadCrumbLabels["trafalis"] = "Δημήτριος Τραφαλής";
breadCrumbLabels["zisaki"] = "Κατερίνα Ζησάκη";
breadCrumbLabels["sanoudou"] = "Δέσποινα Σανούδου";

function displayBreadCrumbs(attempts)
{
	// locate the breadcrumb container
	var theBreadCrumbBar = null;
	if (document.all)
	{
		theBreadCrumbBar = document.all.BreadCrumbBar;
	}
	else
	{
		theBreadCrumbBar = document.getElementById("BreadCrumbBar");
	}
	
	// check to make sure that we have our breadcrumb bar
	if (theBreadCrumbBar != null)
	{
		// get the current url
		// we'll want to ensure that we get the start of our site so, we'll
		//	ignore everything up to and including our site prefix
		var thePath = location.href;
		var theProtocol = "";
		var theSite = "";
		
		// strip out the protocol from the path
		theProtocol = thePath.substring(0, thePath.indexOf("://") + 3);
		thePath = thePath.substring(thePath.indexOf("://") + 3);
		
		// strip out the site name
		theSite = thePath.substring(0, thePath.indexOf(sitePrefix));
		thePath = thePath.substring(thePath.indexOf(sitePrefix));
		
		// strip out the site prefix
		thePath = thePath.substring(thePath.indexOf(sitePrefix) + sitePrefix.length);
		
		// remove hash links
		var theHash = "";
		if (thePath.indexOf("#") > -1)
		{
			theHash = thePath.substring(thePath.indexOf("#"));
			thePath = thePath.substring(0, thePath.indexOf("#"));
		}
		
		// break out the individual pieces of the location
		var crumbs = thePath.split("/");
		var currentPath = sitePrefix;
		var crumbCount = 0;
		
		// add a "home" link
		// create a bread crumb container
		var breadCrumb = document.createElement("span");
		breadCrumb.setAttribute("class", "breadCrumb");
		
		// determine the crumb label
		// first use the default
		var crumbLabel = "Αρχική";
		
		// second look for a generic label
		if ((breadCrumbLabels[sitePrefix] != null))
		{
			crumbLabel = breadCrumbLabels[sitePrefix];
		}
		
		// third look for a specific label
		if ((breadCrumbLabels[currentPath] != null))
		{
			crumbLabel = breadCrumbLabels[currentPath];
		}
		
		// add the text
		// check to see if there are any crumbs after this one
		if ((0 < crumbs.length) &&
			(crumbs[0] != "index.html") &&
			(crumbs[0] != ""))
		{
			// create a new link
			var linkTag = document.createElement("a");
			linkTag.href = theProtocol + theSite + currentPath;
			linkTag.appendChild(document.createTextNode(crumbLabel));
			breadCrumb.appendChild(linkTag);
		}
		else
		{
			// add the text together
			breadCrumb.appendChild(document.createTextNode(crumbLabel));
		}
		theBreadCrumbBar.appendChild(breadCrumb);
		
		// increment our count of crumbs
		crumbCount++;
		
		// loop through the crumbs
		for (var crumbIndex = 0; crumbIndex < crumbs.length; crumbIndex++)
		{
			// setup the current path
			currentPath += crumbs[crumbIndex];
			if (crumbIndex + 1 < crumbs.length)
			{
				currentPath += "/";
			}
			
			if ((crumbs[crumbIndex] != "") &&
				(crumbs[crumbIndex].indexOf("index.html") == -1))
			{
				// add this crumb to the list
				// create a bread crumb container
				var breadCrumb = document.createElement("span");
				breadCrumb.setAttribute("class", "breadCrumb");
				
				// add a greater than to the left hand side
				if (crumbCount > 0)
				{
					breadCrumb.appendChild(document.createTextNode(breadCrumbSeparator));
				}
				
				// determine the crumb label
				// first use the crumb itself
				var crumbLabel = crumbs[crumbIndex].replace(/_/g, " ").replace(".html", "").capitalize();
				
				// second look for a generic label
				if ((breadCrumbLabels[crumbs[crumbIndex]] != null))
				{
					crumbLabel = breadCrumbLabels[crumbs[crumbIndex]];
				}
				
				// third look for a specific label
				if ((breadCrumbLabels[currentPath] != null))
				{
					crumbLabel = breadCrumbLabels[currentPath];
				}
				
				// add the text
				// check to see if there are any crumbs after this one
				if ((crumbIndex + 1 < crumbs.length) &&
					(crumbs[crumbIndex + 1] != "index.html") &&
					(crumbs[crumbIndex + 1] != ""))
				{
					// create a new link
					var linkTag = document.createElement("a");
					linkTag.href = theProtocol + theSite + currentPath;
					linkTag.appendChild(document.createTextNode(crumbLabel));
					breadCrumb.appendChild(linkTag);
				}
				else
				{
					// add the text together
					breadCrumb.appendChild(document.createTextNode(crumbLabel));
				}
				theBreadCrumbBar.appendChild(breadCrumb);
				
				// increment our count of crumbs
				crumbCount++;
			}
		}
	}
	else if (attempts < 5)
	{
		// try again in a few seconds
		attempts++;
		setTimeout("displayBreadCrumbs(" + attempts + ");", 1000);
	}
}

// add a handy function to the string class
String.prototype.capitalize = function()
{
	return this.replace(/\w+/g, function(a)
	{
		return a.charAt(0).toUpperCase() + a.substr(1).toLowerCase();
	});
};

// set us up to display bread crumbs
displayBreadCrumbs(1);
