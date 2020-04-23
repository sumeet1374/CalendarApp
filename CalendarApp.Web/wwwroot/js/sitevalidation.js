$.validator.addMethod("daterange", function (value, _element, params) {

    let today = new Date();
    let todayStart = new Date(today.getFullYear(), today.getMonth(), today.getDate(), 0, 0, 0, 0);
    let todayEnd = new Date(today.getFullYear() + 100, today.getMonth(), today.getDate(), 0, 0, 0, 0);
    let startDate = params['startdate'] ? Date.parse(params['startdate']) : todayStart;
    let endDate = params['enddate'] ? Date.parse(params['enddate']) : todayEnd;
    let excluderangevalues = params['excluderangevalues'];
    let valueToCheck = Date.parse(value); 
    return excluderangevalues ? (valueToCheck > startDate && valueToCheck < endDate) : (valueToCheck >= startDate && valueToCheck <= endDate);

});

$.validator.unobtrusive.adapters.add("daterange", ['startdate', 'enddate', 'excluderangevalues'], function (options) {

    let params = options.params;
    let endDate = params['enddate'] ;
    let excluderangevalues = params['excluderangevalues'];
    let startDate = params['startdate'];
    options.rules['daterange'] = [startDate, endDate, excluderangevalues];
    options.messages['daterange'] = options.message;
});