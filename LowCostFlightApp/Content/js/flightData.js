var orders = new DevExpress.data.CustomStore({
	load: function (loadOptions) {

		var deferred = $.Deferred(),
			args = {};

		if (loadOptions.sort) {
			args.orderby = loadOptions.sort[0].selector;
			if (loadOptions.sort[0].desc)
				args.orderby += " desc";
		}

		args.skip = loadOptions.skip;
		args.take = loadOptions.take;

		$.ajax({
			type: "GET",
			url: '/Home/GetFlight',
			contentType: "application/json; charset=utf-8",
			success: function (result) {
				deferred.resolve(result, { totalCount: result.length });
				
			},
			error: function () {
				deferred.reject("Data Loading Error");
			},
			//timeout: 5000
		});

		return deferred.promise();
	}
});

$("#dxFlightsDataGrid").dxDataGrid({
	dataSource: {
		store: orders
	},
	showBorders: true,
	remoteOperations: {
		sorting: true,
		paging: true
	},
	paging: {
		pageSize: 12
	},
	pager: {
		showPageSizeSelector: true,
		allowedPageSizes: [8, 12, 20]
	},
	columns: [
		{
			caption: "ID",
			dataField: "id",
		},
		{
			caption: "Price",
			dataField: "offerItems[0].price.total",
		},
	]
}).dxDataGrid("instance");