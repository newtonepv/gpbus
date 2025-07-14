// ignore_for_file: prefer_const_constructors

import 'package:flutter/material.dart';
import 'package:tcc_teste/utils/customExceptions/custom_server_exceptions.dart';
import 'package:tcc_teste/utils/server_requests.dart';

class Comments extends StatefulWidget{
  final String password;
  final VoidCallback onCloseWidgetPressed;
  final String userName;
  final int busId;
  const Comments({super.key, required this.onCloseWidgetPressed, required this.busId, required this.userName, required this.password});
  @override
  State<StatefulWidget> createState()=>_ComentsState();
}
class _ComentsState extends State<Comments>{
  int busId=-1;
  bool isloading=true;

  @override
  void initState() {
    busId = widget.busId;
    isloading=true;
    //start croroutine

    super.initState();
  }

  final GlobalKey<_CommentsListState> _commentsListKey = GlobalKey<_CommentsListState>();
  @override
  Widget build(BuildContext context){
    return Center(
      child: Material(
        elevation: 8,
        borderRadius: BorderRadius.circular(16),
        color: Colors.white,
          child: SizedBox(
            width: 400,
            child: ConstrainedBox(
              constraints: BoxConstraints(
                maxHeight: 500, // Adjust this value as needed
              ),
              child:Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                Container(
                  width: double.infinity,
                  padding: EdgeInsets.symmetric(vertical: 12, horizontal: 8),
                  decoration: BoxDecoration(
                    color: const Color.fromARGB(255, 255, 174, 82),
                    borderRadius: BorderRadius.vertical(top: Radius.circular(16)),
                  ),
                  child: Row(
                    children: [
                      IconButton(
                        style: ButtonStyle(
                            shape: MaterialStateProperty.all<RoundedRectangleBorder>(
                              RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(8), // Adjust the radius as needed
                              ),
                            ),
                            backgroundColor: MaterialStateProperty.all<Color>(const Color.fromARGB(255, 255, 255, 255)),
                          ),                    
                        icon: Icon(Icons.close, color: const Color.fromARGB(255, 0, 0, 0)),
                        onPressed: widget.onCloseWidgetPressed,
                        tooltip: "Fechar",
                      ),
                      Expanded(
                        child: Text(
                          "Avaliações do ônibus ${busId.toString()}",
                          style: TextStyle(
                            color: const Color.fromARGB(255, 2, 1, 1),
                            fontSize: 20,
                            fontWeight: FontWeight.bold,
                          ),
                          textAlign: TextAlign.center,
                        ),
                      ),
                      // To keep the title centered, add a SizedBox with same width as IconButton
                      SizedBox(width: 48),
                    ],
                  ),
                ),
                SizedBox(height: 16),
                CommentsList(key: _commentsListKey,busId: busId, userName: widget.userName),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 16.0, vertical: 8.0),
                  child: _CommentInput(
                    onCommentCreated: _commentsListKey.currentState?.fetchComments,
                    userName: widget.userName,
                    password: widget.password,
                    busId: busId
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
  );
  }
}

class CommentsList extends StatefulWidget{
  late int busId;
  late String userName;
  CommentsList({super.key, required this.busId, required this.userName});

  @override 
  _CommentsListState createState() =>_CommentsListState();
}
class _CommentsListState extends State<CommentsList>{
  List<Map<String,dynamic>> comments=[];
  late int busId;
  late String userName;
  bool isloading=true;

  Future<void> fetchComments() async {
    setState(() {
      isloading=true;
    });
    try{
      List<Map<String,dynamic>> fetchedComments = await getBusComments(busId,userName,context);
      setState(() {
        comments=fetchedComments;
        isloading=false;
      });
    }on CustomNavigatedToLoginPageException{
      //do nothing
    }
  }
  @override
  void initState() {
    busId = widget.busId;
    userName = widget.userName;
    fetchComments();//start coroutine
    super.initState();
  }

  @override 
  Widget build(BuildContext context)=>
  isloading
    ? Center(
        child: Padding(
          padding: const EdgeInsets.all(32.0),
          child: CircularProgressIndicator(),
        ),
      )
    : comments.isEmpty
      ? Padding(
          padding: const EdgeInsets.all(16.0),
          child: Text(
            "Nenhum comentário encontrado.",
            style: TextStyle(color: Colors.black54),
          ),
        )
      :  Flexible(
    child: ListView.builder(
      shrinkWrap: true,
      itemCount: comments.length,
      itemBuilder: (context, index) {
        return _CommentWidget(userName: userName,comment:comments[index],onLiked:fetchComments);
      },
    )
  );
  
}

class _CommentWidget extends StatefulWidget {
  final Map<String,dynamic> comment;
  final String userName;
  final Function onLiked;
  const _CommentWidget({required this.comment, required this.userName, required this.onLiked,});

  @override
  State<_CommentWidget> createState() => _CommentWidgetState();
}

class _CommentWidgetState extends State<_CommentWidget> {
  late Map<String,dynamic> comment;
  late String userName;
  late Function onLiked;
  

  @override
  void initState() {
    onLiked=widget.onLiked;
    comment=widget.comment;
    userName=widget.userName;
    super.initState();
  }

@override
Widget build(BuildContext context)=> Padding(
    padding: const EdgeInsets.symmetric(horizontal: 12.0, vertical: 6.0),
    child: Card(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(12),
      ),
      elevation: 2,
      child: Padding(
        padding: const EdgeInsets.all(12.0),
        child: Column(
          mainAxisSize: MainAxisSize.min,
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                Text(
                  comment['userName'] ?? '',
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 16,
                  ),
                ),
                Spacer(),
                Row(
                  children: List.generate(
                    5,
                    (star) => Icon(
                      Icons.star,
                      size: 18,
                      color: star < (comment['stars'] ?? 0)
                          ? Colors.amber
                          : Colors.grey[300],
                    ),
                  ),
                ),
              ],
            ),
            SizedBox(height: 4),
            Text(
              comment['message'] ?? '',
              style: TextStyle(fontSize: 15),
            ),
            SizedBox(height: 8),
            Row(
              children: [
                IconButton(onPressed: ()async{
                  int intercactionCode = 0; //turn into not dislike
                  if(comment['userInteraction'] != 1){
                    intercactionCode=1;//if the button isnt selected it turns into dislike
                  }
                  try{
                    await likeComment(userName, comment['id'],intercactionCode,context);
                    onLiked();
                  }on CustomNavigatedToLoginPageException{
                    //do nothing
                  }
                }, 
                icon: Icon(
                    (comment['userInteraction'] == 1)
                        ? Icons.thumb_up_alt
                        : Icons.thumb_up_alt_outlined,
                    size: 16,
                    color: Colors.green,
                  ),
                ),
                SizedBox(width: 4),
                Text('${comment['likes'] ?? 0}'),

                SizedBox(width: 16),

                IconButton(onPressed: ()async{
                  int intercactionCode = 0; //turn into not dislike
                  if(comment['userInteraction'] != -1){
                    intercactionCode=-1;//if the button isnt selected it turns into dislike
                  }
                  try{
                    await likeComment(userName, comment['id'],intercactionCode,context);
                    onLiked();
                  }on CustomNavigatedToLoginPageException{
                    //do nothing
                  }
                }, 
                icon: Icon(
                    (comment['userInteraction'] == -1)
                      ? Icons.thumb_down_alt
                      : Icons.thumb_down_alt_outlined,
                    size: 16,
                    color: Colors.red,
                  ),
                ),
                
                SizedBox(width: 4),
                Text('${comment['disLikes'] ?? 0}'),
                Spacer(),
                Text(
                  comment['date'] != null
                      ? comment['date'].toString().split('T').first
                      : '',
                  style: TextStyle(fontSize: 12, color: Colors.grey[600]),
                ),
              ],
            ),
          ],
        ),
      ),
    ),
  );
}

class _CommentInput extends StatefulWidget {
  final String userName;
  final String password;
  final int busId;
  final Future<void> Function()? onCommentCreated;
  const _CommentInput({required this.userName,required this.password, required this.busId, required this.onCommentCreated});

  @override
  State<_CommentInput> createState() => _CommentInputState();
}

class _CommentInputState extends State<_CommentInput> {
  final TextEditingController _controller = TextEditingController();
  int _selectedStars = 0;
  bool isLoading = false;

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text("Deixe seu comentário:", style: TextStyle(fontWeight: FontWeight.bold)),
        Row(
          children: List.generate(
            5,
            (index) => IconButton(
              icon: Icon(
                Icons.star,
                color: index < _selectedStars ? Colors.amber : Colors.grey[300],
              ),
              onPressed: () {
                setState(() {
                  _selectedStars = index + 1;
                });
              },
              iconSize: 28,
              padding: EdgeInsets.zero,
              constraints: BoxConstraints(),
            ),
          ),
        ),
        TextField(
          controller: _controller,
          decoration: InputDecoration(
            hintText: "Digite seu comentário...",
            border: OutlineInputBorder(borderRadius: BorderRadius.circular(8)),
            contentPadding: EdgeInsets.symmetric(horizontal: 12, vertical: 8),
          ),
          minLines: 1,
          maxLines: 3,
        ),
        Align(
          alignment: Alignment.centerRight,
          child: ElevatedButton(
            onPressed: () async{
              if (_controller.text.trim().isNotEmpty && _selectedStars > 0) {
                String commentMsg=_controller.text.trim();
                int commentStarts= _selectedStars;
                _controller.clear();
                setState(() {
                  _selectedStars = 0;
                  isLoading=true;
                });
                try{
                  await createComment(widget.busId,widget.userName,widget.password, commentStarts,commentMsg,context);
                  widget.onCommentCreated!();
                  setState(() {
                    isLoading=false;
                  });
                }on CustomNavigatedToLoginPageException{
                  //do nothing
                }
              }

            },
            child: isLoading?CircularProgressIndicator():Text("Enviar"),
          ),
        ),
      ],
    );
  }
}

