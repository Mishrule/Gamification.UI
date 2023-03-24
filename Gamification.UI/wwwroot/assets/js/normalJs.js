//set data to local storage
function setData(point, level, badge) {
	localStorage.setItem('level', level);
	localStorage.setItem('point', point);
	localStorage.setItem('badge', badge);
}

$("#aLevel").text(localStorage.getItem('level'));
$("#aBadge").text(localStorage.getItem('badge'));
$("#aPoint").text(localStorage.getItem('point'));


//returns the process string
//function processes(process) {
//	return process;
//}

var queryString = window.location.search;// Returns the query string from the current URL

var params = new URLSearchParams(queryString);

// Get the value of the first query parameter
var firstValue = params.get(params.keys().next().value);





function returnProcess(process) {
	var output = "";
	switch (process) {
	
		case "FI":
			output = "Financial Accounting";
			break;
		case "SD":
			output = "Sales and Distribution";
			break;
		case "PP":
			output = "Production Planning";
			break;
		case "FI_AR":
			output = "Financial Account Receivable";
			break;
		case "MM":
			output = "Material Management";
			break;
		
		default:
			break;
			
	}

	return output;
}
