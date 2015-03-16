function pathDraw2(x_,y_,z_,xr_,yr_,zr_)

clf

ax = axes('XLim',[-10 10],'YLim',[-10 10],'ZLim',[-10 10]);
view(3);
grid on;
axis equal

[xc yc zc] = cylinder([0.1 0.0]);


h(1) = surface( xc,         zc,         -yc, 'FaceColor', 'red');
    
t = hgtransform('Parent',ax);
set(h,'Parent',t)

set(gcf,'Renderer', 'opengl')

drawnow
%t
x = x_(1:end); % lon
y = z_(1:end); % dummy
z = y_(1:end); % lat
%r
rotx = xr_(1:end);
roty = zr_(1:end);
rotz = yr_(1:end);
% convert to radians:
rotx = -rotx ./ 180 .* pi;
roty = -roty ./ 180 .* pi;
rotz = -rotz ./ 180 .* pi;

% labels:
xlabel('x');
ylabel('y');
zlabel('z');
% hold on;

for i = 1:numel(x)
    % make the translation:
    trans = makehgtform('translate',[x(i) y(i) z(i)]);
    % make the rotation:
    rotax = makehgtform('xrotate', rotx(i));
    rotay = makehgtform('yrotate', roty(i));
    rotaz = makehgtform('zrotate', rotz(i));
    % apply:
    set(t,'Matrix', trans*rotax*rotay*rotaz); 
    
    if i >= 2
        %line(x(i+1),z(i+1));
        line([x(i) x(i-1)], [y(i) y(i-1)], [z(i) z(i-1)]);
    end
    
    %set(t,'Matrix', trans*rotay);
    %set(t,'Matrix', trans*rotaz);
    pause%(0.001);
    
    if 0
        trans = makehgtform('translate',[0 0 0]);
        
        rotax = makehgtform('xrotate', 0);
        rotay = makehgtform('yrotate', 0);
        rotaz = makehgtform('zrotate', 0);
        set(t,'Matrix', trans*rotax*rotay*rotaz);
        pause
    end
    
end
    