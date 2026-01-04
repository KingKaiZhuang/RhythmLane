.PHONY: gen-chart

# Run the chart generation script from the SongGenerateChart workspace
gen-chart:
	source /Users/stackpenguin/Documents/SongGenerateChart/env/bin/activate && streamlit run /Users/stackpenguin/Documents/SongGenerateChart/generate_chart.py
