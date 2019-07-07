
function GetData() {
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

			var url = "/Home/GetFlight?origin=" +
				$("#depertureIATA").val() + "&destination=" +
				$("#arrivalIATA").val() + "&depatureDate=" + $("#depatureDate").val()
				+ "&arrivateDate=" + $("#arrivalDate").val() + "&currency=" + $("#currency").val();
			$.ajax({
				type: "GET",
				url: url,
				contentType: "application/json; charset=utf-8",
				success: function (result) {
					deferred.resolve(result, { totalCount: result.length });

				},
				error: function () {
					if ($("#depertureIATA").val("") || $("#arrivalIATA").val("") || $("#depatureDate").val("") || ("#arrivalDate").val("") || $("#currency").val(""))
						deferred.reject("Unesite vrijednost u filtere!");
					else
						deferred.reject("Data Loading Error");
				},
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
		filterRow: { visible: true },
		columns: [
			{
				caption: "Odlazak",
				dataField: "StartAirport",
			},
			{
				caption: "Dolazak",
				dataField: "EndAirport",
			},
			{
				caption: "Vrijeme odlaska",
				dataField: "StartDateAndTime",
				dataType: 'date',
				format: 'dd/MM/yyyy hh:mm',
				width: 200
			},
			{
				caption: "Vrijeme dolaska",
				dataField: "EndDateAndTime",
				dataType: 'date',
				format: 'dd/MM/yyyy hh:mm',
				width: 200
			},
			{
				caption: "Broj putnika",
				dataField: "NumberOfPassangers",
			},
			{
				caption: "Broj presjedanja u odlasku",
				dataField: "Start",
			},
			{
				caption: "Broj presjedanja u dolasku",
				dataField: "End",
			},
			{
				caption: "Cijena",
				dataField: "Price",
			},
			{
				caption: "Valuta",
				dataField: "Currency",
			},
		]
	}).dxDataGrid("instance");
}

function ClearData()
{
	var grid = $('#dxFlightsDataGrid').dxDataGrid('instance');
	grid.option('dataSource', []);
}


