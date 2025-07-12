import 'package:flutter/material.dart';

class BusSearchBar extends StatefulWidget {
  final String hintText;
  final List<int> busIds;
  final Function(int) onBusSelected;
  
  const BusSearchBar({
    Key? key,
    required this.busIds,
    required this.onBusSelected,
    required this.hintText
  }) : super(key: key);

  @override
  State<BusSearchBar> createState() => _BusSearchBarState();
}

class _BusSearchBarState extends State<BusSearchBar> {
  final SearchController searchController = SearchController();
  late String hintText;
  
  void updateHintText(String newHint) {
    setState(() {
      hintText = newHint;
    });
  }

  @override
  void initState() {
    hintText=widget.hintText;
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SearchAnchor(
      searchController: searchController,
      builder: (BuildContext context, SearchController controller) {
        return SearchBar(
          controller: controller,
          padding: const WidgetStatePropertyAll<EdgeInsets>(
            EdgeInsets.symmetric(horizontal: 16.0),
          ),
          onTap: () {
            controller.openView();
          },
          onChanged: (_) {
            controller.openView();
          },
          leading: const Icon(Icons.search),
          hintText: hintText,
        );
      },
      suggestionsBuilder: (BuildContext context, SearchController controller) {
        return widget.busIds
            .where((int busId) {
              return busId.toString().contains(controller.text.toLowerCase());
            })
            .map((int busId) => ListTile(
                title: Text(busId.toString()),
                onTap: () {
                          searchController.closeView(busId.toString());
                          setState(() {
                            hintText=busId.toString();
                          });
                          widget.onBusSelected(busId);} ,
              )
            );
      },
    );
  }
}