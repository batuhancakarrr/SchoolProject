$("#chart").on("click", function () {
	$("#chartoverlay").fadeIn();

	am5.ready(function () {
		var root = am5.Root.new("chartdiv");
		root._logo.dispose();
		root.setThemes([am5themes_Animated.new(root)]);

		var chart = root.container.children.push(am5xy.XYChart.new(root, {
			panX: true,
			panY: true,
			wheelX: "panX",
			wheelY: "zoomX",
			pinchZoomX: true,
			paddingLeft: 0,
			paddingRight: 1
		}));

		var cursor = chart.set("cursor", am5xy.XYCursor.new(root, {}));
		cursor.lineY.set("visible", false);

		var xRenderer = am5xy.AxisRendererX.new(root, {
			minGridDistance: 30,
			minorGridEnabled: true
		});

		xRenderer.labels.template.setAll({
			rotation: -90,
			centerY: am5.p50,
			centerX: am5.p100,
			paddingRight: 15
		});

		xRenderer.grid.template.setAll({
			location: 1
		});

		var xAxis = chart.xAxes.push(am5xy.CategoryAxis.new(root, {
			maxDeviation: 0.3,
			categoryField: "className",
			renderer: xRenderer,
			tooltip: am5.Tooltip.new(root, {})
		}));

		var yRenderer = am5xy.AxisRendererY.new(root, {
			strokeOpacity: 0.1
		});

		var yAxis = chart.yAxes.push(am5xy.ValueAxis.new(root, {
			maxDeviation: 0.3,
			renderer: yRenderer
		}));

		var series = chart.series.push(am5xy.ColumnSeries.new(root, {
			name: "��renci Say�s�",
			xAxis: xAxis,
			yAxis: yAxis,
			valueYField: "studentCount",
			sequencedInterpolation: true,
			categoryXField: "className",
			tooltip: am5.Tooltip.new(root, {
				labelText: "{valueY}"
			})
		}));

		series.columns.template.setAll({ cornerRadiusTL: 5, cornerRadiusTR: 5, strokeOpacity: 0 });
		series.columns.template.adapters.add("fill", function (fill, target) {
			return chart.get("colors").getIndex(series.columns.indexOf(target));
		});

		series.columns.template.adapters.add("stroke", function (stroke, target) {
			return chart.get("colors").getIndex(series.columns.indexOf(target));
		});

		function loadClassData() {
			$.ajax({
				url: '/Classes/GetClassStudentCounts',
				method: 'POST',
				success: function (response) {
					if (response.success) {


						xAxis.data.setAll(response.data);
						series.data.setAll(response.data);

						series.appear(1000);
						chart.appear(1000, 100);
					} else {
						console.error("Data y�klenirken bir hata olu�tu: ", response.message);
					}
				},
				error: function (error) {
					console.error("Data y�klenirken bir hata olu�tu: ", error);
				}
			});
		}

		loadClassData();
	}); 
});
$("#chartoverlay").on("click", function (e) {
	if (e.target.id === "chartoverlay") {
		$("#chartoverlay").fadeOut();
	}
});
