import pandas as pd
import os
import xml.etree.ElementTree as ET

# Ruta del archivo de entrada
input_path = r"C:\Users\GARCIAS\Downloads\sales_data"

# Cargar el archivo en memoria
try:
    data = pd.read_csv(input_path)
except FileNotFoundError:
    print("El archivo no se encontró en la ruta especificada.")
    exit()

# Filtrar las filas donde la columna 'state' no esté vacía
data = data.dropna(subset=['state'])

# Crear el árbol XML
root = ET.Element("SalesData")

for _, row in data.iterrows():
    entry = ET.SubElement(root, "Entry")
    for col in data.columns:
        child = ET.SubElement(entry, col)
        child.text = str(row[col])

# Especificar la carpeta y ruta de salida
output_dir = r"C:\Users\GARCIAS\Downloads\processed_data"
os.makedirs(output_dir, exist_ok=True)
output_path = os.path.join(output_dir, "filtered_sales_data.xml")

# Guardar el archivo XML
tree = ET.ElementTree(root)
tree.write(output_path, encoding="utf-8", xml_declaration=True)

print(f"El archivo XML ha sido guardado en: {output_path}")